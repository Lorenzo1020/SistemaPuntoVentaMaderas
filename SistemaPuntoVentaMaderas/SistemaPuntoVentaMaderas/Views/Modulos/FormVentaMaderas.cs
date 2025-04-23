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

namespace SistemaPuntoVentaMaderas
{
    public partial class FormVentaMaderas : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();

        public FormVentaMaderas()
        {
            InitializeComponent();
            dataGridVentaMaderas.Columns[0].Visible = false;

            mostrarVentasMaderas();
        }

        public void mostrarVentasMaderas()
        {
            dataGridVentaMaderas.Rows.Clear();
            conexionBd = new Model1();

            var listarVentasRealizdas = (from a in conexionBd.VentasSet select a);

            foreach (VentasSet v in listarVentasRealizdas)
            {
                //Darle formato a la fecha de registro
                var dateTime = v.FechaVenta;

                dataGridVentaMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre+" "+v.ClientesSet.App+" "+v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.TotalProducto, v.PrecioTotal,v.PagoCon,v.Deuda,v.NombreEntrega,v.NombreRecibe);
            }

        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            var validarSiHayClientes = (from a in conexionBd.ClientesSet
                                          where a.Estatus == 1
                                          select a);

            if (validarSiHayClientes.Count() > 0)
            {
                FormDetallesVentaMaderas formDetallesVentaMaderas = new FormDetallesVentaMaderas(false, 0);
                formDetallesVentaMaderas.ShowDialog();
                mostrarVentasMaderas();

            }
            else
                MessageBox.Show("No se puede, debe agregar al menos un cliente, para realiza una venta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
        }

        private void txbMadera_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridVentaMaderas.Rows.Clear();
            conexionBd = new Model1();

            var ventaEncontrados = (from c in conexionBd.VentasSet
                                     where (c.ClientesSet.Nombre.Contains(txbCliente.Text) || c.ClientesSet.App.Contains(txbCliente.Text) || c.ClientesSet.Apm.Contains(txbCliente.Text))
                                     select c);

            if (ventaEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (VentasSet v in ventaEncontrados)
                {
                    var dateTime = v.FechaVenta;

                    dataGridVentaMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre + " " + v.ClientesSet.App + " " + v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.TotalProducto, v.PrecioTotal, v.PagoCon, v.Deuda, v.NombreEntrega, v.NombreRecibe);
                }
            }
            else
            {
                lbrespuesta.Text = "No hay ventas de ese cliente";

                if (txbCliente.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }
    }
}
