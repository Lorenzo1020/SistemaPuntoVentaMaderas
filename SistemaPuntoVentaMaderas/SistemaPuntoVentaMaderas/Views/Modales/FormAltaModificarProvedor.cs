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
    public partial class FormAltaModificarProvedor : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idProveedor = 0;

        public FormAltaModificarProvedor(Boolean boolGuardar, int obtengoIdProved)
        {
            InitializeComponent();


            //Al cargar el formulario se ejecuta esto para ver si es guardar o editar
            this.boolGuardar = boolGuardar;
            idProveedor = obtengoIdProved;


            if (boolGuardar == false)
            {
                btnGuardar.Text = "Guardar";
            }

            else
            {
                btnGuardar.Text = "Modificar";

                var provedorEncontrado = (from a in conexionBd.ProveedoresSet
                                         where a.IdProveedor == idProveedor
                                         select a);

                foreach (ProveedoresSet p in provedorEncontrado)
                {
                    textBoxNombre.Text = p.Nombre;
                    textBoxApp.Text = p.App;
                    textBoxApm.Text = p.Apm;
                    textBoxCelular.Text = p.NumCel;
                    textBoxCorreo.Text = p.Correo;
                    textBoxCalle.Text = p.Calle;
                    textBoxNumExt.Text = p.NumExt;
                    textBoxNumInt.Text = p.NumInt;
                    textBoxEstado.Text = p.Estado;
                    textBoxCiudad.Text = p.Ciudad;
                    richTextBoxNombreEmpresa.Text = p.NombreEmpresa;


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
                    MessageBox.Show("Debe ingresar nombre del proveedor", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxNombre.Focus();

                }

                else if (textBoxApp.Text == "")
                {
                    MessageBox.Show("Debe ingresar apellido paterno", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxApp.Focus();

                }

                else if (textBoxApm.Text == "")
                {
                    MessageBox.Show("Debe Ingresar apellido materno", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxApm.Focus();

                }
                else if (textBoxCelular.Text == "")
                {
                    MessageBox.Show("Debe Ingresar número de celular", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCelular.Focus();

                }
                else if (textBoxCalle.Text == "")
                {
                    MessageBox.Show("Debe Ingresar calle", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCalle.Focus();

                }

                else if (textBoxEstado.Text == "")
                {
                    MessageBox.Show("Debe Ingresar estado", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxEstado.Focus();

                }

                else if (textBoxCiudad.Text == "")
                {
                    MessageBox.Show("Debe Ingresar ciudad", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCiudad.Focus();

                }

                else
                {
                    Boolean banderaCorreo = true;
                    if (textBoxCorreo.Text != "")
                    {
                        if (textBoxCorreo.Text.IndexOf('@') == -1 || textBoxCorreo.Text.IndexOf('.') == -1)
                        {
                            MessageBox.Show("Su correo no esta correcto ", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBoxCorreo.Text = "";
                            textBoxCorreo.Focus();
                            banderaCorreo = false;
                        }

                    }

                    //Si el correo esta vacio o lo ingresan y tienen el formato correcto si podemos guardar
                    if (banderaCorreo == true)
                    {
                        var listaProveedor = (from a in conexionBd.ProveedoresSet
                                            select a);

                        Boolean bandera = false;
                        foreach (ProveedoresSet p in listaProveedor)
                        {
                            if (p.Nombre.Equals(textBoxNombre.Text) && p.App.Equals(textBoxApp.Text) && p.Apm.Equals(textBoxApm.Text))
                            {
                                MessageBox.Show("Ese proveedor ya existe", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                bandera = true;
                                break;
                            }
                        }

                        if (!bandera)
                        {

                            ProveedoresSet provedorNuevo = new ProveedoresSet();

                            provedorNuevo.Nombre = textBoxNombre.Text;
                            provedorNuevo.App = textBoxApp.Text;
                            provedorNuevo.Apm = textBoxApm.Text;
                            provedorNuevo.NumCel = textBoxCelular.Text;
                            provedorNuevo.Correo = textBoxCorreo.Text;

                            DateTime fechaActual = DateTime.Now;
                            provedorNuevo.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                            provedorNuevo.Estatus = 1;
                            provedorNuevo.Calle = textBoxCalle.Text;
                            provedorNuevo.NumExt = textBoxNumExt.Text;
                            provedorNuevo.NumInt = textBoxNumInt.Text;
                            provedorNuevo.Estado = textBoxEstado.Text;
                            provedorNuevo.Ciudad = textBoxCiudad.Text;
                            provedorNuevo.NombreEmpresa = richTextBoxNombreEmpresa.Text;

                            conexionBd.ProveedoresSet.Add(provedorNuevo);
                            conexionBd.SaveChanges();
                            this.Close();

                        }

                    }

                }
            }

            else
            {

                if (textBoxNombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar nombre del cliente", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxNombre.Focus();

                }

                else if (textBoxApp.Text == "")
                {
                    MessageBox.Show("Debe ingresar apellido paterno", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxApp.Focus();

                }

                else if (textBoxApm.Text == "")
                {
                    MessageBox.Show("Debe Ingresar apellido materno", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxApm.Focus();

                }
                else if (textBoxCelular.Text == "")
                {
                    MessageBox.Show("Debe Ingresar número de celular", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCelular.Focus();

                }

                else if (textBoxCalle.Text == "")
                {
                    MessageBox.Show("Debe Ingresar calle", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCalle.Focus();

                }

                else if (textBoxEstado.Text == "")
                {
                    MessageBox.Show("Debe Ingresar estado", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxEstado.Focus();

                }

                else if (textBoxCiudad.Text == "")
                {
                    MessageBox.Show("Debe Ingresar ciudad", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCiudad.Focus();

                }

                else
                {
                    Boolean banderaCorreo = true;
                    if (textBoxCorreo.Text != "")
                    {
                        if (textBoxCorreo.Text.IndexOf('@') == -1 || textBoxCorreo.Text.IndexOf('.') == -1)
                        {
                            MessageBox.Show("Su correo no esta correcto ", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBoxCorreo.Text = "";
                            textBoxCorreo.Focus();
                            banderaCorreo = false;
                        }

                    }

                    //Si el correo esta vacio o lo ingresan y tienen el formato correcto si podemos guardar
                    if (banderaCorreo == true)
                    {
                        ProveedoresSet proveedorEncontrado = conexionBd.ProveedoresSet.Where(x => x.IdProveedor == idProveedor).Select(x => x).FirstOrDefault();

                        proveedorEncontrado.Nombre = textBoxNombre.Text;
                        proveedorEncontrado.App = textBoxApp.Text;
                        proveedorEncontrado.Apm = textBoxApm.Text;
                        proveedorEncontrado.NumCel = textBoxCelular.Text;
                        proveedorEncontrado.Correo = textBoxCorreo.Text;
                        proveedorEncontrado.Calle = textBoxCalle.Text;
                        proveedorEncontrado.NumExt = textBoxNumExt.Text;
                        proveedorEncontrado.NumInt = textBoxNumInt.Text;
                        proveedorEncontrado.Estado = textBoxEstado.Text;
                        proveedorEncontrado.Ciudad = textBoxCiudad.Text;
                        proveedorEncontrado.NombreEmpresa = richTextBoxNombreEmpresa.Text;

                        //Actualizacion del registro
                        conexionBd.SaveChanges();

                        this.Close();
                    }


                }

            }

        }

        private void textBoxCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }
    }
}
