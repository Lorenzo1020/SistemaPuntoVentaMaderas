using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoVentaMaderas.Models;
using SistemaPuntoVentaMaderas.Views.Modales;

namespace SistemaPuntoVentaMaderas
{
    public partial class FormProveedores : Form
    {
        Model1 conexionBd = new Model1();

        public FormProveedores()
        {
            InitializeComponent();

            dataGridListaProveedores.Columns[0].Visible = false;
            dataGridListaProveedores.Columns[6].Width = 300;
            mostrarClientes();
        }

        public void mostrarClientes()
        {

            dataGridListaProveedores.Rows.Clear();
            conexionBd = new Model1();


            var listaProvedores = (from a in conexionBd.ProveedoresSet
                                          where a.Estatus == 1
                                          select a);

            foreach (ProveedoresSet p in listaProvedores)
            {
                //Darle formato a la fecha de registro
                var dateTime = p.FechaRegistro;
                dataGridListaProveedores.Rows.Add(p.IdProveedor, p.Nombre + " " + p.App + " " + p.Apm, p.NombreEmpresa, p.NumCel, p.Correo, dateTime.ToShortDateString(), p.Calle + " " + p.NumExt + " " + p.NumInt + " " + p.Ciudad + " " + p.Estado);
            }


        }

        private void txbProvedor_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridListaProveedores.Rows.Clear();
            conexionBd = new Model1();

            var proveedorEncontrados = (from c in conexionBd.ProveedoresSet
                                      where ((c.Nombre.Contains(txbProvedor.Text) || c.App.Contains(txbProvedor.Text) || c.Apm.Contains(txbProvedor.Text)) && c.Estatus == 1)
                                      select c);

            if (proveedorEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (ProveedoresSet p in proveedorEncontrados)
                {
                    //Darle formato a la fecha de registro
                    var dateTime = p.FechaRegistro;
                    dataGridListaProveedores.Rows.Add(p.IdProveedor, p.Nombre + " " + p.App + " " + p.Apm, p.NombreEmpresa, p.NumCel, p.Correo, dateTime.ToShortDateString(), p.Calle + " " + p.NumExt + " " + p.NumInt + " " + p.Ciudad + " " + p.Estado);
                }
            }
            else
            {
                lbrespuesta.Text = "No se encontro el proveedor";

                if (txbProvedor.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridListaProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridListaProveedores.Rows.Count > 0)
            {
                //obtenemos el id del cliente con el doble click en el datagrid
                int idProveedor = Convert.ToInt32(this.dataGridListaProveedores.CurrentRow.Cells[0].Value);

                 FormAltaModificarProvedor formAltaModificarProvedor = new FormAltaModificarProvedor(true, idProveedor);
                formAltaModificarProvedor.ShowDialog();
                mostrarClientes();

                txbProvedor.Focus();
                txbProvedor.Text = "";
                lbrespuesta.Text = "";
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Nuevo formulario a mostrar --- le mando false de que el cliente sera nuevo
            FormAltaModificarProvedor formAltaModificarProvedor = new FormAltaModificarProvedor(false, 0);
            //Oculto formulario actual
            //this.Hide();
            //Muestro el nuevo formulario
            formAltaModificarProvedor.ShowDialog();
            mostrarClientes();

            txbProvedor.Focus();
            txbProvedor.Text = "";
            lbrespuesta.Text = "";
        }
    }
}
