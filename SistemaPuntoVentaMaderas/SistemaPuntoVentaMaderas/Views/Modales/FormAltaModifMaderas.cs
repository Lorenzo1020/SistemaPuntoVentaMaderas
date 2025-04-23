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

namespace SistemaPuntoVentaMaderas.Views.Modales
{
    public partial class FormAltaModifMaderas : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idMadera = 0;

        public FormAltaModifMaderas(Boolean boolGuardar, int obtengoIdMadera)
        {
            InitializeComponent();

            //Al cargar el formulario se ejecuta esto para ver si es guardar o editar
            this.boolGuardar = boolGuardar;
            idMadera = obtengoIdMadera;


            if (boolGuardar == false)
            {
                btnGuardar.Text = "Guardar";
            }

            else
            {
                btnGuardar.Text = "Modificar";

                textBoxEstock.Enabled = false;

                var maderaEncontrado = (from a in conexionBd.MaderasSet
                                        where a.IdMadera == idMadera
                                        select a);

                foreach (MaderasSet m in maderaEncontrado)
                {
                    textBoxNombre.Text = m.Nombre;
                    richTextBoxDescripcion.Text = m.Descripcion;
                    textBoxEstock.Text= m.Stock.ToString();
                    textBoxStockControl.Text = m.StockControl.ToString();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar nuevo cliente
            if (boolGuardar == false)
            {

                if (textBoxNombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar nombre de madera", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxNombre.Focus();

                }

                else if (richTextBoxDescripcion.Text == "")
                {
                    MessageBox.Show("Debe ingresar descripción", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    richTextBoxDescripcion.Focus();

                }
                else if (textBoxEstock.Text == "")
                {
                    MessageBox.Show("Debe ingresar stock inicial", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxEstock.Focus();
                }
                else if (textBoxStockControl.Text == "")
                {
                    MessageBox.Show("Debe ingresar stock de control", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxStockControl.Focus();

                }
                else
                {

                    var listaMadera = (from a in conexionBd.MaderasSet
                                       select a);

                    Boolean bandera = false;
                    foreach (MaderasSet m in listaMadera)
                    {
                        if (m.Nombre.Equals(textBoxNombre.Text))
                        {
                            MessageBox.Show("Esa madera ya existe", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bandera = true;
                            break;
                        }
                    }

                    if (!bandera)
                    {

                        MaderasSet maderaNuevo = new MaderasSet();

                        maderaNuevo.Nombre = textBoxNombre.Text;
                        maderaNuevo.Descripcion = richTextBoxDescripcion.Text;
                        maderaNuevo.Estatus = 1;
                        maderaNuevo.Stock = Convert.ToInt64(textBoxEstock.Text.ToString());
                        maderaNuevo.StockControl = Convert.ToInt64(textBoxStockControl.Text.ToString());

                        DateTime fechaActual = DateTime.Now;
                        maderaNuevo.FechaMovInventario = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                        conexionBd.MaderasSet.Add(maderaNuevo);
                        conexionBd.SaveChanges();
                        this.Close();

                    }

                }
            }
            else  //MODIFICANDO LA INFORMACION
            {
                if (textBoxNombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar nombre de madera", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxNombre.Focus();

                }

                else if (richTextBoxDescripcion.Text == "")
                {
                    MessageBox.Show("Debe ingresar descripción", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    richTextBoxDescripcion.Focus();

                }
                else if (textBoxStockControl.Text == "")
                {
                    MessageBox.Show("Debe ingresar stock de control", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxStockControl.Focus();

                }

                else
                {

                    MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();

                    maderaEncontrado.Nombre = textBoxNombre.Text;
                    maderaEncontrado.Descripcion = richTextBoxDescripcion.Text;

                    maderaEncontrado.StockControl = Convert.ToInt64(textBoxStockControl.Text.ToString());

                    conexionBd.SaveChanges();
                    this.Close();


                }
            }
        }

        private void textBoxEstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }

        private void textBoxStockControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }
    }
}
