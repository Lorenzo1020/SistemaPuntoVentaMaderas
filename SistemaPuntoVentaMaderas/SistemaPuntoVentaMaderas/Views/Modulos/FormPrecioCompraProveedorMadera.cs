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

namespace SistemaPuntoVentaMaderas
{
    public partial class FormPrecioCompraProveedorMadera : Form
    {
        Model1 conexionBd = new Model1();

        public FormPrecioCompraProveedorMadera()
        {
            InitializeComponent();
            dataGridListaMaderas.Columns[0].Visible = false;
            dataGridListaMaderas.Columns[4].Width = 200;
            mostrarPrecioCompraMaderas();
        }

        public void mostrarPrecioCompraMaderas()
        {

            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();


            var listaPrecioComProvdMaderas = (from a in conexionBd.PrecioCompraProveedorSet 
                                              where a.Estatus == 1 select a);

            foreach (PrecioCompraProveedorSet m in listaPrecioComProvdMaderas)
            {

                //Concateno nombre completo de proveedor
                String nombreCompleto = m.ProveedoresSet.Nombre + " " + m.ProveedoresSet.App + " " + m.ProveedoresSet.Apm;

                dataGridListaMaderas.Rows.Add(m.IdPrecioCpm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, nombreCompleto, m.PrecioMadera,"Editar");
            }


        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Para mostrar el formulario siguiente validar que cumpla con esta condicion
            var validarSiHayMaderas = (from a in conexionBd.MaderasSet
                                       where a.Estatus == 1
                                       select a);

            var validarSiHayProvedores = (from a in conexionBd.ProveedoresSet
                                        where a.Estatus == 1
                                        select a);

            if (validarSiHayMaderas.Count() > 0 && validarSiHayProvedores.Count() > 0)
            {
                FormAltModPrecioProveMad formAltModPrecioProveMad = new FormAltModPrecioProveMad(false, 0);
                formAltModPrecioProveMad.ShowDialog();
                mostrarPrecioCompraMaderas();

            }
            else
                MessageBox.Show("No se puede, debe agregar al menos una madera y un proveedor, para realiza esta operación", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

           
            txbMadera.Focus();
            txbMadera.Text = "";
            lbrespuesta.Text = "";
        }

        private void txbMadera_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();

            var maderaEncontrado = (from c in conexionBd.PrecioCompraProveedorSet
                                      where ((c.MaderasSet.Nombre.Contains(txbMadera.Text) || c.MaderasSet.Descripcion.Contains(txbMadera.Text)) && c.Estatus == 1)
                                      select c);

            if (maderaEncontrado.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (PrecioCompraProveedorSet m in maderaEncontrado)
                {
                    

                    //Concateno nombre completo de proveedor
                    String nombreCompleto = m.ProveedoresSet.Nombre + " " + m.ProveedoresSet.App + " " + m.ProveedoresSet.Apm;

                    dataGridListaMaderas.Rows.Add(m.IdPrecioCpm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, nombreCompleto, m.PrecioMadera,"Editar");
                }
            }
            else
            {
                lbrespuesta.Text = "No se encontro la madera";

                if (txbMadera.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridListaMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dataGridListaMaderas.Rows.Count > 0)
                {
                    //obtenemos el id del cliente con el doble click en el datagrid
                    int idPrecioComprPromad = Convert.ToInt32(this.dataGridListaMaderas.CurrentRow.Cells[0].Value);

                    FormAltModPrecioProveMad formAltModPrecioProve = new FormAltModPrecioProveMad(true, idPrecioComprPromad);
                    formAltModPrecioProve.ShowDialog();
                    mostrarPrecioCompraMaderas();

                    txbMadera.Focus();
                    txbMadera.Text = "";
                    lbrespuesta.Text = "";
                }
            }
        }
    }
}
