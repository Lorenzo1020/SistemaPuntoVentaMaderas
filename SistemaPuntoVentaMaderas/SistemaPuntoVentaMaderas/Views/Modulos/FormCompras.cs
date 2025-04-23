using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoVentaMaderas.View;
using SistemaPuntoVentaMaderas.Models;

namespace SistemaPuntoVentaMaderas
{
    public partial class FormCompras : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        
        public FormCompras()
        {
            InitializeComponent();
            dataGridComprasMaderas.Columns[0].Visible = false;

            mostrarComprasMaderas();

        }

        public void mostrarComprasMaderas()
        {
            dataGridComprasMaderas.Rows.Clear();
            conexionBd = new Model1();

            var listarComprasRealizdas = (from a in conexionBd.ComprasSet select a);

            foreach (ComprasSet c in listarComprasRealizdas)
            {
                //Darle formato a la fecha de registro
                var dateTime = c.FechaCompra;

                dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.TotalProducto, c.PrecioTotal, c.PagoCon, c.Deuda, c.NombreEntrega, c.NombreRecibe);
            }

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var validarSiHayProvedores = (from a in conexionBd.ProveedoresSet
                                          where a.Estatus == 1
                                          select a);

            if (validarSiHayProvedores.Count() > 0)
            {
                FormDetallesComprasMaderas formDetallesComprasMaderas = new FormDetallesComprasMaderas(false, 0);
                formDetallesComprasMaderas.ShowDialog();
                mostrarComprasMaderas();

            }
            else
                MessageBox.Show("No se puede, debe agregar al menos un proveedor, para realiza una compra", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
        }

        private void txbProvedor_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridComprasMaderas.Rows.Clear();
            conexionBd = new Model1();

            var compraEncontrados = (from c in conexionBd.ComprasSet
                                     where (c.ProveedoresSet.Nombre.Contains(txbProvedor.Text) || c.ProveedoresSet.App.Contains(txbProvedor.Text) || c.ProveedoresSet.Apm.Contains(txbProvedor.Text))
                                     select c);

            if (compraEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (ComprasSet c in compraEncontrados)
                {
                    var dateTime = c.FechaCompra;

                    dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.TotalProducto, c.PrecioTotal, c.PagoCon, c.Deuda, c.NombreEntrega, c.NombreRecibe);
                }
            }
            else
            {
                lbrespuesta.Text = "No hay compras de ese proveedor";

                if (txbProvedor.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }
    }
}
