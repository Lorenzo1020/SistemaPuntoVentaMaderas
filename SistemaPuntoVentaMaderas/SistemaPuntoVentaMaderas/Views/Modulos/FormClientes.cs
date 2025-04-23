using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoVentaMaderas.View.Modales;
using SistemaPuntoVentaMaderas.Models;

namespace SistemaPuntoVentaMaderas.View
{
    public partial class FormClientes : Form
    {
        Model1 conexionBd = new Model1();

        public FormClientes()
        {
            InitializeComponent();
            dataGridListaClientes.Columns[0].Visible = false;
            dataGridListaClientes.Columns[6].Width = 300;
            mostrarClientes();
        }

        public void mostrarClientes()
        {

            dataGridListaClientes.Rows.Clear();
            conexionBd = new Model1();


            var listaClientesActivados = (from a in conexionBd.ClientesSet
                                    where a.Estatus == 1
                                    select a);

            foreach (ClientesSet c in listaClientesActivados)
            {
                //Darle formato a la fecha de registro
                var dateTime = c.FechaRegistro;
                dataGridListaClientes.Rows.Add(c.IdCliente, c.Nombre+" "+c.App+" "+c.Apm, c.NombreEmpresa, c.NumCel, c.Correo, dateTime.ToShortDateString(), c.Calle + " " + c.NumExt + " " + c.NumInt + " " + c.Ciudad + " " + c.Estado);
            }


        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Nuevo formulario a mostrar --- le mando false de que el cliente sera nuevo
            FormAltaModicarClientes frmAltaModClient = new FormAltaModicarClientes(false, 0);
            //Oculto formulario actual
            //this.Hide();
            //Muestro el nuevo formulario
            frmAltaModClient.ShowDialog();
            mostrarClientes();

            txbcliente.Focus();
            txbcliente.Text = "";
            lbrespuesta.Text = "";
        }

        private void txbcliente_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridListaClientes.Rows.Clear();
            conexionBd = new Model1();

            var clienteEncontrados = (from c in conexionBd.ClientesSet
                          where ((c.Nombre.Contains(txbcliente.Text) || c.App.Contains(txbcliente.Text) || c.Apm.Contains(txbcliente.Text)) && c.Estatus==1)
                          select c);

            if (clienteEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (ClientesSet c in clienteEncontrados)
                {
                    //Darle formato a la fecha de registro
                    var dateTime = c.FechaRegistro;
                    dataGridListaClientes.Rows.Add(c.IdCliente, c.Nombre + " " + c.App + " " + c.Apm, c.NombreEmpresa, c.NumCel, c.Correo, dateTime.ToShortDateString(), c.Calle + " " + c.NumExt + " " + c.NumInt + " " + c.Ciudad + " " + c.Estado);
                }
            }
            else
            {
                lbrespuesta.Text = "No se encontro el cliente";

                if (txbcliente.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridListaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridListaClientes.Rows.Count > 0)
            {
                //obtenemos el id del cliente con el doble click en el datagrid
                int idcliente = Convert.ToInt32(this.dataGridListaClientes.CurrentRow.Cells[0].Value);

                FormAltaModicarClientes frmAltaModClient = new FormAltaModicarClientes(true, idcliente);
                frmAltaModClient.ShowDialog();
                mostrarClientes();

                txbcliente.Focus();
                txbcliente.Text = "";
                lbrespuesta.Text = "";
            }
        }
    }
}
