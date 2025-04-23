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
    public partial class FormAgregarModificarAbonoClients : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        int obtengoIdVentaOelIdAbono = 0;

        public FormAgregarModificarAbonoClients(int obtengoIdCompraOelIdAbono)
        {
            InitializeComponent();

            //Recibo el obtengoIdCompraOelIdAbono para mostrar la informacion inicial en le formulario
            this.obtengoIdVentaOelIdAbono = obtengoIdCompraOelIdAbono;
            btnGuardar.Text = "Guardar";

            var ventaEncontradoAbonar = (from a in conexionBd.VentasSet
                                          where a.IdVenta == obtengoIdCompraOelIdAbono
                                          select a);

            foreach (VentasSet m in ventaEncontradoAbonar)
            {
                textBoxCliente.Text = m.ClientesSet.Nombre + " " + m.ClientesSet.App + " " + m.ClientesSet.Apm;
                textBoxDebe.Text = m.Deuda.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar nuevo abono
            if (textBoxAbono.Text == "")
            {
                MessageBox.Show("Debe ingresar la cantidad de abono", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxAbono.Focus();

            }
            else if (Convert.ToDouble(textBoxAbono.Text.ToString()) > Convert.ToDouble(textBoxDebe.Text.ToString()))
            {
                MessageBox.Show("Rectifica el abono, no es justo", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxAbono.Focus();
            }
            else if (textBoxRecibeAbono.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de quien recibe el abono", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxRecibeAbono.Focus();

            }
            else
            {
                Double canculandoLoqueDebe = 0;

                RegistroAbonoClientesSet registroAbonoClientes = new RegistroAbonoClientesSet();

                registroAbonoClientes.FechaAbono = Convert.ToDateTime(dateTimeFechaAbono.Text);
                registroAbonoClientes.Debia = Convert.ToDouble(textBoxDebe.Text.ToString());
                registroAbonoClientes.Abono = Convert.ToDouble(textBoxAbono.Text.ToString());

                canculandoLoqueDebe = Convert.ToDouble(textBoxDebe.Text.ToString()) - Convert.ToDouble(textBoxAbono.Text.ToString());
                registroAbonoClientes.Debe = canculandoLoqueDebe;

                registroAbonoClientes.RecibeAbono = textBoxRecibeAbono.Text;
                registroAbonoClientes.Ventas_IdVenta = obtengoIdVentaOelIdAbono;

                conexionBd.RegistroAbonoClientesSet.Add(registroAbonoClientes);
                conexionBd.SaveChanges();

                //Actualizando tambien la deuda en la venta
                VentasSet encontradoRegistroParaActualizar = conexionBd.VentasSet.Where(x => x.IdVenta == obtengoIdVentaOelIdAbono).Select(x => x).FirstOrDefault();
                encontradoRegistroParaActualizar.Deuda = canculandoLoqueDebe;
                conexionBd.SaveChanges();
                this.Close();

            }
        }

        private void textBoxAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales.aceptasolonumerodecimal(sender, e, ('.'));
        }
    }
}
