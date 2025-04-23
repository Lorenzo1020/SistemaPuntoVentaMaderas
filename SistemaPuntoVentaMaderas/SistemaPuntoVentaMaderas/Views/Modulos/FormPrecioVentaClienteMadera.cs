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
using SistemaPuntoVentaMaderas.View.Modales;

namespace SistemaPuntoVentaMaderas
{
    public partial class FormPrecioVentaClienteMadera : Form
    {
        Model1 conexionBd = new Model1();

        public FormPrecioVentaClienteMadera()
        {
            InitializeComponent();

            dataGridListaMaderas.Columns[0].Visible = false;
            dataGridListaMaderas.Columns[4].Width = 200;
            mostrarPrecioVentaMaderas();
        }

        public void mostrarPrecioVentaMaderas()
        {

            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();


            var listaPrecioVenClientMaderas = (from a in conexionBd.PrecioVentaClienteSet 
                                               where a.Estatus == 1 select a);

            foreach (PrecioVentaClienteSet m in listaPrecioVenClientMaderas)
            {
                
                //Concateno nombre completo de proveedor
                String nombreCompleto = m.ClientesSet.Nombre + " " + m.ClientesSet.App + " " + m.ClientesSet.Apm;

                dataGridListaMaderas.Rows.Add(m.IdPrecioVcm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, nombreCompleto, m.PrecioMadera,"Editar");
            }


        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Para mostrar el formulario siguiente validar que cumpla con esta condicion
            var validarSiHayMaderas = (from a in conexionBd.MaderasSet
                                               where a.Estatus == 1
                                               select a);

            var validarSiHayClientes = (from a in conexionBd.ClientesSet
                                       where a.Estatus == 1
                                       select a);

            if (validarSiHayMaderas.Count() > 0 && validarSiHayClientes.Count() > 0)
            {
                FormAltModPrecioVentaClienMad formAltModPrecioVentaClienMad = new FormAltModPrecioVentaClienMad(false, 0);
                formAltModPrecioVentaClienMad.ShowDialog();
                mostrarPrecioVentaMaderas();

            }
            else
                MessageBox.Show("No se puede, debe agregar al menos una madera y un cliente, para realiza esta operación", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            txbMadera.Focus();
            txbMadera.Text = "";
            lbrespuesta.Text = "";

        }

        private void txbMadera_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();

            var maderaEncontrado = (from c in conexionBd.PrecioVentaClienteSet
                                    where ((c.MaderasSet.Nombre.Contains(txbMadera.Text) || c.MaderasSet.Descripcion.Contains(txbMadera.Text)) && c.Estatus == 1)
                                    select c);

            if (maderaEncontrado.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (PrecioVentaClienteSet m in maderaEncontrado)
                {
                    
                    //Concateno nombre completo de proveedor
                    String nombreCompleto = m.ClientesSet.Nombre + " " + m.ClientesSet.App + " " + m.ClientesSet.Apm;

                    dataGridListaMaderas.Rows.Add(m.IdPrecioVcm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, nombreCompleto, m.PrecioMadera, "Editar");
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

                    FormAltModPrecioVentaClienMad formAltModPrecioVentaClienMad = new FormAltModPrecioVentaClienMad(true, idPrecioComprPromad);
                    formAltModPrecioVentaClienMad.ShowDialog();
                    mostrarPrecioVentaMaderas();

                    txbMadera.Focus();
                    txbMadera.Text = "";
                    lbrespuesta.Text = "";
                }
            }
        }
    }
}
