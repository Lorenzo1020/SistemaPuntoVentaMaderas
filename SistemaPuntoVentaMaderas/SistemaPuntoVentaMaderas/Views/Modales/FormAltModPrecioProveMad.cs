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
    public partial class FormAltModPrecioProveMad : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idPrecioCompProvdMa = 0;

        public FormAltModPrecioProveMad(Boolean boolGuardar, int obtengoIdPrecioCompProvdMad)
        {
            InitializeComponent();

            //Al cargar el formulario se ejecuta esto para ver si es guardar o editar
            this.boolGuardar = boolGuardar;
            idPrecioCompProvdMa = obtengoIdPrecioCompProvdMad;

            llenarComboMaderas();
            llenarComboPreoveedores();

            if (boolGuardar == false)
            {
                btnGuardar.Text = "Guardar";
            }

            else
            {
                btnGuardar.Text = "Modificar";

                

                var precioCompProvmaderaEncontrado = (from a in conexionBd.PrecioCompraProveedorSet
                                        where a.IdPrecioCpm == idPrecioCompProvdMa
                                        select a);

                foreach (PrecioCompraProveedorSet m in precioCompProvmaderaEncontrado)
                {
                    comboBoxMadera.SelectedValue=m.MaderasSet.IdMadera;
                    comboBoxProvedor.SelectedValue = m.ProveedoresSet.IdProveedor;
                    textBoxPrecio.Text = m.PrecioMadera.ToString();
                }
            }
        }

        private void llenarComboMaderas()
        {
            List<MaderasSet> listaMaderas = conexionBd.MaderasSet.ToList();

            if (listaMaderas.Count > 0)
            {
                comboBoxMadera.DataSource = listaMaderas;
                comboBoxMadera.DisplayMember = "nombre";
                comboBoxMadera.ValueMember = "IdMadera";
            }
        }


        private void llenarComboPreoveedores()
        {
            List<ProveedoresSet> listaProveedores = conexionBd.ProveedoresSet.ToList();

            if (listaProveedores.Count > 0)
            {
                comboBoxProvedor.DataSource = listaProveedores;
                comboBoxProvedor.DisplayMember = "nombre";
                comboBoxProvedor.ValueMember = "IdProveedor";
            }
        }

        //Es en el evento Format, le pongo nombre del evento y de doy en clic
        private void pasandoDatosCompleto(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((MaderasSet)e.ListItem).Nombre;
            string descripcion = ((MaderasSet)e.ListItem).Descripcion;

            e.Value = nombre + " " + descripcion;
        }

        private void pasandoDatosCompletoProvd(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((ProveedoresSet)e.ListItem).Nombre;
            string app = ((ProveedoresSet)e.ListItem).App;
            string apm = ((ProveedoresSet)e.ListItem).Apm;

            e.Value = nombre + " " + app +" "+apm;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (boolGuardar == false)
            {


                if (textBoxPrecio.Text == "")
                {
                    MessageBox.Show("Debe ingresar precio compra", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxPrecio.Focus();
                }
                

                else
                {

                    var listaPrecioCompraProvedor = (from a in conexionBd.PrecioCompraProveedorSet
                                                   select a);

                    Boolean bandera = false;
                    foreach (PrecioCompraProveedorSet p in listaPrecioCompraProvedor)
                    {
                        if (p.Maderas_IdMadera == Convert.ToInt16(comboBoxMadera.SelectedValue.ToString()) && p.Proveedores_IdProveedor == Convert.ToInt16(comboBoxProvedor.SelectedValue.ToString()))
                        {
                            MessageBox.Show("Anteriormente ya agrego ese registro", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bandera = true;
                            break;
                        }
                    }

                    if (bandera == false)
                    {
                        PrecioCompraProveedorSet nuevoRegistro = new PrecioCompraProveedorSet();


                        nuevoRegistro.PrecioMadera = Convert.ToDouble(textBoxPrecio.Text.ToString());
                        nuevoRegistro.Estatus = 1;
                        nuevoRegistro.Proveedores_IdProveedor = Convert.ToInt32(comboBoxProvedor.SelectedValue.ToString());
                        nuevoRegistro.Maderas_IdMadera = Convert.ToInt32(comboBoxMadera.SelectedValue.ToString());

                        conexionBd.PrecioCompraProveedorSet.Add(nuevoRegistro);
                        conexionBd.SaveChanges();
                        this.Close();
                    }
                }
            }
            else ///Apartado para editar
            {

                if (textBoxPrecio.Text == "")
                {
                    MessageBox.Show("Debe ingresar precio compra", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxPrecio.Focus();
                }

                else
                {

                    PrecioCompraProveedorSet encontradoPrecioCompraProvMad = conexionBd.PrecioCompraProveedorSet.Where(x => x.IdPrecioCpm == idPrecioCompProvdMa).Select(x => x).FirstOrDefault();


                    encontradoPrecioCompraProvMad.PrecioMadera = Convert.ToDouble(textBoxPrecio.Text.ToString());
                    encontradoPrecioCompraProvMad.Proveedores_IdProveedor = Convert.ToInt32(comboBoxProvedor.SelectedValue.ToString());
                    encontradoPrecioCompraProvMad.Maderas_IdMadera = Convert.ToInt32(comboBoxMadera.SelectedValue.ToString());

                 
                    conexionBd.SaveChanges();
                    this.Close();


                }

            }
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales.aceptasolonumerodecimal(sender, e, ('.'));
        }
    }
}
