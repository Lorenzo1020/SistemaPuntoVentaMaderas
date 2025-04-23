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
    public partial class Form1 : Form
    {
        Model1 conexionBd = new Model1();

        public Form1()
        {
            InitializeComponent();
            textBoxUsuario.Focus();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            var listaUsuarios = (from u in conexionBd.UsuariosSet
                         select u);

            if (listaUsuarios.Count() > 0) {

                if (textBoxUsuario.TextLength > 0 && textBoxContrasena.TextLength >0)
                {
                    Boolean bandera = false;

                    foreach (UsuariosSet usuario in listaUsuarios)
                    {
                        if (usuario.Usuario.Equals(textBoxUsuario.Text) && usuario.Contrasena.Equals(textBoxContrasena.Text))
                        {
                            FormPrincipal formPrincipal = new FormPrincipal();
                            this.Hide();

                            formPrincipal.ShowDialog();
                            this.Show();

                            bandera = true;
                            break;
                        }

                    }

                    if (!bandera)
                        MessageBox.Show("Usuario o Contraseña incorrecto", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Favor de completar los campos", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No hay ningun registro de usuarios", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
