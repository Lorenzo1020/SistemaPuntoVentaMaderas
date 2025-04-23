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
    public partial class FormAltModPrecioVentaClienMad : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idPrecioVentaClientMa = 0;

        public FormAltModPrecioVentaClienMad(Boolean boolGuardar, int obtengoIdPrecioVenClintMad)
        {
            InitializeComponent();

            //Al cargar el formulario se ejecuta esto para ver si es guardar o editar
            this.boolGuardar = boolGuardar;
            idPrecioVentaClientMa = obtengoIdPrecioVenClintMad;

            llenarComboMaderas();
            llenarComboCliente();

            if (boolGuardar == false)
            {
                btnGuardar.Text = "Guardar";
            }

            else
            {
                btnGuardar.Text = "Modificar";

                var precioVentClintmaderaEncontrado = (from a in conexionBd.PrecioVentaClienteSet
                                                      where a.IdPrecioVcm == idPrecioVentaClientMa
                                                      select a);

                foreach (PrecioVentaClienteSet m in precioVentClintmaderaEncontrado)
                {
                    comboBoxMadera.SelectedValue = m.MaderasSet.IdMadera;
                    comboBoxCliente.SelectedValue = m.ClientesSet.IdCliente;
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

        private void llenarComboCliente()
        {
            List<ClientesSet> listaClientes = conexionBd.ClientesSet.ToList();

            if (listaClientes.Count > 0)
            {
                comboBoxCliente.DataSource = listaClientes;
                comboBoxCliente.DisplayMember = "nombre";
                comboBoxCliente.ValueMember = "IdCliente";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (boolGuardar == false)
            {

                if (textBoxPrecio.Text == "")
                {
                    MessageBox.Show("Debe ingresar precio venta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxPrecio.Focus();
                }
                else
                {
                    var listaPrecioVentaCliente = (from a in conexionBd.PrecioVentaClienteSet
                                       select a);

                    Boolean bandera = false;
                    foreach (PrecioVentaClienteSet p in listaPrecioVentaCliente)
                    {
                        if (p.Maderas_IdMadera== Convert.ToInt16(comboBoxMadera.SelectedValue.ToString()) && p.Clientes_IdCliente== Convert.ToInt16(comboBoxCliente.SelectedValue.ToString()))
                        {
                            MessageBox.Show("Anteriormente ya agrego ese registro", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bandera = true;
                            break;
                        }
                    }

                    if (bandera == false)
                    {
                        PrecioVentaClienteSet nuevoRegistro = new PrecioVentaClienteSet();


                        nuevoRegistro.PrecioMadera = Convert.ToDouble(textBoxPrecio.Text.ToString());
                        nuevoRegistro.Estatus = 1;
                        nuevoRegistro.Clientes_IdCliente = Convert.ToInt32(comboBoxCliente.SelectedValue.ToString());
                        nuevoRegistro.Maderas_IdMadera = Convert.ToInt32(comboBoxMadera.SelectedValue.ToString());

                        conexionBd.PrecioVentaClienteSet.Add(nuevoRegistro);
                        conexionBd.SaveChanges();
                        this.Close();
                    }
                    
                }
            }
            else
            {
                PrecioVentaClienteSet encontradoPrecioVentaClientMad = conexionBd.PrecioVentaClienteSet.Where(x => x.IdPrecioVcm == idPrecioVentaClientMa).Select(x => x).FirstOrDefault();


                encontradoPrecioVentaClientMad.PrecioMadera = Convert.ToDouble(textBoxPrecio.Text.ToString());
                encontradoPrecioVentaClientMad.Clientes_IdCliente = Convert.ToInt32(comboBoxCliente.SelectedValue.ToString());
                encontradoPrecioVentaClientMad.Maderas_IdMadera = Convert.ToInt32(comboBoxMadera.SelectedValue.ToString());

                conexionBd.SaveChanges();
                this.Close();


            }
        }

        private void pasandoDatosCompleto(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((MaderasSet)e.ListItem).Nombre;
            string descripcion = ((MaderasSet)e.ListItem).Descripcion;

            e.Value = nombre + " " + descripcion;
        }

        private void pasandoDatosCompletoClient(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((ClientesSet)e.ListItem).Nombre;
            string app = ((ClientesSet)e.ListItem).App;
            string apm = ((ClientesSet)e.ListItem).Apm;

            e.Value = nombre + " " + app + " " + apm;
        }

        private void textBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales.aceptasolonumerodecimal(sender, e, ('.'));
        }
    }
}
