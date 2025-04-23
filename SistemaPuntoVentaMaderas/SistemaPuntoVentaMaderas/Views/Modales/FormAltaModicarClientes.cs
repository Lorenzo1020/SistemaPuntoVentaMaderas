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


namespace SistemaPuntoVentaMaderas.View.Modales
{
    public partial class FormAltaModicarClientes : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idCliente=0;

        public FormAltaModicarClientes(Boolean boolGuardar, int obtengoIdCliente)
        {
            InitializeComponent();

            //Al cargar el formulario se ejecuta esto para ver si es guardar o editar
            this.boolGuardar = boolGuardar;
            idCliente = obtengoIdCliente;
           

            if (boolGuardar == false)
            {
                btnGuardar.Text = "Guardar";
            }

            else
            {
                btnGuardar.Text = "Modificar";

                var clienteEncontrado = (from a in conexionBd.ClientesSet
                               where a.IdCliente == idCliente
                               select a);

                foreach (ClientesSet c in clienteEncontrado)
                {
                    textBoxNombre.Text = c.Nombre;
                    textBoxApp.Text = c.App;
                    textBoxApm.Text = c.Apm;
                    textBoxCelular.Text = c.NumCel;
                    textBoxCorreo.Text = c.Correo;
                    textBoxCalle.Text = c.Calle;
                    textBoxNumExt.Text = c.NumExt;
                    textBoxNumInt.Text = c.NumInt;
                    textBoxEstado.Text = c.Estado;
                    textBoxCiudad.Text = c.Ciudad;
                    richTextBoxNombreEmpresa.Text = c.NombreEmpresa;

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
                        var listaCliente = (from a in conexionBd.ClientesSet
                                            select a);

                        Boolean bandera = false;
                        foreach (ClientesSet cliente in listaCliente)
                        {
                            if (cliente.Nombre.Equals(textBoxNombre.Text) && cliente.App.Equals(textBoxApp.Text) && cliente.Apm.Equals(textBoxApm.Text))
                            {
                                MessageBox.Show("Ese cliente ya existe", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                bandera = true;
                                break;
                            }
                        }

                        if (!bandera)
                        {

                            ClientesSet clienteNuevo = new ClientesSet();

                            clienteNuevo.Nombre = textBoxNombre.Text;
                            clienteNuevo.App = textBoxApp.Text;
                            clienteNuevo.Apm = textBoxApm.Text;
                            clienteNuevo.NumCel = textBoxCelular.Text;
                            clienteNuevo.Correo = textBoxCorreo.Text;

                            DateTime fechaActual = DateTime.Now;
                            clienteNuevo.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                            clienteNuevo.Estatus = 1;
                            clienteNuevo.Calle = textBoxCalle.Text;
                            clienteNuevo.NumExt = textBoxNumExt.Text;
                            clienteNuevo.NumInt = textBoxNumInt.Text;
                            clienteNuevo.Estado = textBoxEstado.Text;
                            clienteNuevo.Ciudad = textBoxCiudad.Text;
                            clienteNuevo.NombreEmpresa = richTextBoxNombreEmpresa.Text;

                            conexionBd.ClientesSet.Add(clienteNuevo);
                            conexionBd.SaveChanges();
                            this.Close();

                            /*Que se muestre nuevamente los registros---Invoco el formulario de FormClientes
                            FormClientes formClientes = new FormClientes();
                            formClientes.ShowDialog();
                            */
                        }

                    }

                }
            }
            else //--------------------------CODIGO PARA EDITAR EL CLIENTE UTILIZANDO EL MISMO FORMS
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
                        ClientesSet clienteEncontrado = conexionBd.ClientesSet.Where(x => x.IdCliente == idCliente).Select(x => x).FirstOrDefault();

                        clienteEncontrado.Nombre = textBoxNombre.Text;
                        clienteEncontrado.App = textBoxApp.Text;
                        clienteEncontrado.Apm = textBoxApm.Text;
                        clienteEncontrado.NumCel = textBoxCelular.Text;
                        clienteEncontrado.Correo = textBoxCorreo.Text;
                        clienteEncontrado.Calle = textBoxCalle.Text;
                        clienteEncontrado.NumExt = textBoxNumExt.Text;
                        clienteEncontrado.NumInt = textBoxNumInt.Text;
                        clienteEncontrado.Estado = textBoxEstado.Text;
                        clienteEncontrado.Ciudad = textBoxCiudad.Text;
                        clienteEncontrado.NombreEmpresa = richTextBoxNombreEmpresa.Text;

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
