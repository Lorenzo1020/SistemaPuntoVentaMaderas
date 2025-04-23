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
    public partial class FormInventarioMaderas : Form
    {
        Model1 conexionBd = new Model1();
        int idMaderaEnontrado = 0;

        public FormInventarioMaderas()
        {
            InitializeComponent();
        }

        public void mostrarRegitroEncontrado()
        {
            var maderaEncontrado = (from c in conexionBd.MaderasSet
                                    where (c.Nombre == texBoxNombreMadera.Text)
                                    select c);

            if (maderaEncontrado.Count() > 0)
            {
                foreach (MaderasSet m in maderaEncontrado)
                {
                    richTxbDescripcion.Text = m.Descripcion;
                    texBoxStock.Text = m.Stock.ToString();
                    //Paso el id e la variable
                    idMaderaEnontrado = m.IdMadera;
                    comboBoxAgregarQuitar.SelectedIndex = 0;
                    comboBoxAgregarQuitar.Enabled = true;
                    texBoxAgregar.Enabled = true;
                    texBoxAgregar.Text = "";
                    btnGuardar.Enabled = true;
                    break;
                }
            }
            else
            {
                richTxbDescripcion.Text = "";
                texBoxStock.Text = "";
                idMaderaEnontrado = 0;

                MessageBox.Show("No se encontro ese registro", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                texBoxNombreMadera.Focus();
            }
        }

        private void buttonBuscarNombre_Click(object sender, EventArgs e)
        {
            mostrarRegitroEncontrado();


        }

        private void texBoxNombreMadera_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            richTxbDescripcion.Text = "";
            texBoxStock.Text = "";
            comboBoxAgregarQuitar.Enabled = false;
            texBoxAgregar.Enabled = false;
            txbQuitar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (idMaderaEnontrado > 0) {

                if (texBoxAgregar.Text != "" || txbQuitar.Text != "")
                {
                    if (comboBoxAgregarQuitar.SelectedIndex == 0)
                    { //Agregando a inventario

                        MaderasSet encontraMadera = conexionBd.MaderasSet.Where(x => x.IdMadera == idMaderaEnontrado).Select(x => x).FirstOrDefault();

                        long caculoStockOperacionAgrega = encontraMadera.Stock + Convert.ToInt64(texBoxAgregar.Text.ToString());

                        //Actualizo el stock
                        encontraMadera.Stock = caculoStockOperacionAgrega;
                        //Actualizar fecha de movimiento de inventario
                        DateTime fechaActual = DateTime.Now;
                        encontraMadera.FechaMovInventario = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                        conexionBd.SaveChanges();
                        mostrarRegitroEncontrado();

                    }
                    else if (comboBoxAgregarQuitar.SelectedIndex == 1)
                    {
                        MaderasSet encontraMadera = conexionBd.MaderasSet.Where(x => x.IdMadera == idMaderaEnontrado).Select(x => x).FirstOrDefault();

                        if (Convert.ToInt64(txbQuitar.Text.ToString()) > Convert.ToInt64(texBoxStock.Text.ToString()))
                        {

                            MessageBox.Show("La cantidad ingresada es mayor ala cantidad de existencia, ingrese una cantidad menor", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txbQuitar.Focus();
                        }
                        else
                        {
                            long caculoStockOperacionQuit = encontraMadera.Stock - Convert.ToInt64(txbQuitar.Text.ToString());
                            //Actualizo el stock
                            encontraMadera.Stock = caculoStockOperacionQuit;
                            //Actualizar fecha de movimiento de inventario
                            DateTime fechaActual = DateTime.Now;
                            encontraMadera.FechaMovInventario = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                            conexionBd.SaveChanges();
                            mostrarRegitroEncontrado();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void txbQuitar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }

        private void texBoxAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }

        private void comboBoxAgregarQuitar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAgregarQuitar.SelectedIndex == 0)
            {
                texBoxAgregar.Enabled = true;
                btnGuardar.Enabled = true;
                txbQuitar.Enabled = false;
                txbQuitar.Text = "";
            }
            else
            {
                txbQuitar.Enabled = true;
                btnGuardar.Enabled = true;
                texBoxAgregar.Enabled = false;
                texBoxAgregar.Text = "";
            }
        }
    }
}
