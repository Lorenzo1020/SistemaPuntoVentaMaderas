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
using SistemaPuntoVentaMaderas.Views.Modales;

namespace SistemaPuntoVentaMaderas
{

    public partial class FormMaderas : Form
    {
        Model1 conexionBd = new Model1();

        public FormMaderas()
        {
            InitializeComponent();
            dataGridListaMaderas.Columns[0].Visible = false;
            dataGridListaMaderas.Columns[1].Width = 300;

            mostrarMaderas();
        }

        public void mostrarMaderas()
        {

            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();


            var listaMaderasActivados = (from a in conexionBd.MaderasSet
                                          where a.Estatus == 1
                                          select a);

            foreach (MaderasSet m in listaMaderasActivados)
            {
                //Darle formato a la fecha de registro
                var dateTime = m.FechaMovInventario;

                dataGridListaMaderas.Rows.Add(m.IdMadera, m.Nombre,m.Descripcion, m.Stock, dateTime.ToShortDateString(), m.StockControl,"Editar");
            }


        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Nuevo formulario a mostrar --- le mando false de que el cliente sera nuevo
            FormAltaModifMaderas formAltaModifMaderas = new FormAltaModifMaderas(false, 0);
            
            //Muestro el nuevo formulario
            formAltaModifMaderas.ShowDialog();
            mostrarMaderas();

            txbMadera.Focus();
            txbMadera.Text = "";
            lbrespuesta.Text = "";
        }

        private void txbMadera_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridListaMaderas.Rows.Clear();
            conexionBd = new Model1();

            var maderaEncontrados = (from c in conexionBd.MaderasSet
                                      where ((c.Nombre.Contains(txbMadera.Text) || c.Descripcion.Contains(txbMadera.Text)) && c.Estatus == 1)
                                      select c);

            if (maderaEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (MaderasSet m in maderaEncontrados)
                {
                    //Darle formato a la fecha de registro
                    var dateTime = m.FechaMovInventario;

                    dataGridListaMaderas.Rows.Add(m.IdMadera, m.Nombre, m.Descripcion, m.Stock, dateTime.ToShortDateString(), m.StockControl,"Editar");
                }
            }
            else
            {
                lbrespuesta.Text = "No se encontro esa madera";

                if (txbMadera.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridListaMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridListaMaderas.Rows.Count > 0)
                {
                    //obtenemos el id del cliente con el doble click en el datagrid
                    int idMadera = Convert.ToInt32(this.dataGridListaMaderas.CurrentRow.Cells[0].Value);

                    FormAltaModifMaderas formAltaModifMaderas = new FormAltaModifMaderas(true, idMadera);
                    formAltaModifMaderas.ShowDialog();
                    mostrarMaderas();

                    txbMadera.Focus();
                    txbMadera.Text = "";
                    lbrespuesta.Text = "";
                }
            }
        }
    }
}
