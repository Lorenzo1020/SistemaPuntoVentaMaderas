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
    public partial class FormAgregarModificarAbonoProveds : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        int obtengoIdCompraOelIdAbono = 0;


        public FormAgregarModificarAbonoProveds(int obtengoIdCompraOelIdAbono)
        {
            InitializeComponent();

            //Recibo el idCompraOidAbono para mostrar la informacion inicial en le formulario
            this.obtengoIdCompraOelIdAbono = obtengoIdCompraOelIdAbono;
            btnGuardar.Text = "Guardar";

            var compraEncontradoAbonar = (from a in conexionBd.ComprasSet
                                          where a.IdCompra == obtengoIdCompraOelIdAbono
                                          select a);

            foreach (ComprasSet m in compraEncontradoAbonar)
            {
                textBoxProvedor.Text = m.ProveedoresSet.Nombre + " " + m.ProveedoresSet.App + " " + m.ProveedoresSet.Apm;
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

                RegistroAbonoProveedorSet registroAbonoProveedor = new RegistroAbonoProveedorSet();

                registroAbonoProveedor.FechaAbono = Convert.ToDateTime(dateTimeFechaAbono.Text);
                registroAbonoProveedor.Debia = Convert.ToDouble(textBoxDebe.Text.ToString());
                registroAbonoProveedor.Abono = Convert.ToDouble(textBoxAbono.Text.ToString());

                canculandoLoqueDebe = Convert.ToDouble(textBoxDebe.Text.ToString()) - Convert.ToDouble(textBoxAbono.Text.ToString());
                registroAbonoProveedor.Debe = canculandoLoqueDebe;

                registroAbonoProveedor.RecibeAbono = textBoxRecibeAbono.Text;
                registroAbonoProveedor.Compras_IdCompra = obtengoIdCompraOelIdAbono;

                conexionBd.RegistroAbonoProveedorSet.Add(registroAbonoProveedor);
                conexionBd.SaveChanges();

                //Actualizando tambien la deuda en la compra
                ComprasSet encontradoRegistroParaActualizar = conexionBd.ComprasSet.Where(x => x.IdCompra == obtengoIdCompraOelIdAbono).Select(x => x).FirstOrDefault();
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
