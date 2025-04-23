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

namespace SistemaPuntoVentaMaderas
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FormClientes frmClientes = new FormClientes();
            frmClientes.ShowDialog();
        }

        private void btnMaderas_Click(object sender, EventArgs e)
        {
            FormMaderas formMaderas = new FormMaderas();
            formMaderas.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormProveedores formProvedores = new FormProveedores();
            formProvedores.ShowDialog();
        }

        private void btnPrecioCompraMadera_Click(object sender, EventArgs e)
        {
            FormPrecioCompraProveedorMadera formPrecioCompraProveedorMadera=new FormPrecioCompraProveedorMadera();
            formPrecioCompraProveedorMadera.ShowDialog();
        }

        private void btnPrecioVentaMadera_Click(object sender, EventArgs e)
        {
           FormPrecioVentaClienteMadera formPrecioVentaClienteMadera = new FormPrecioVentaClienteMadera();
            formPrecioVentaClienteMadera.ShowDialog();
        }

        private void btnInventarioMadera_Click(object sender, EventArgs e)
        {
            FormInventarioMaderas formInventarioMaderas = new FormInventarioMaderas();
            formInventarioMaderas.ShowDialog();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVentaMaderas formVentaMaderas = new FormVentaMaderas();
            formVentaMaderas.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormCompras formCompras = new FormCompras();
            formCompras.ShowDialog();

        }

        private void buttonAbonosProved_Click(object sender, EventArgs e)
        {
            FormAbonosProveedores formAbonosProveedores = new FormAbonosProveedores();
            formAbonosProveedores.ShowDialog();
        }

        private void buttonAbonosClientes_Click(object sender, EventArgs e)
        {
            FormAbonosClientes formAbonosClientes = new FormAbonosClientes();
            formAbonosClientes.ShowDialog();
        }
    }
}
