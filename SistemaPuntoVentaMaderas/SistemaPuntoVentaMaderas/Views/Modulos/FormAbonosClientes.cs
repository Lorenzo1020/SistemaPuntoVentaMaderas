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
    public partial class FormAbonosClientes : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();

        public FormAbonosClientes()
        {
            InitializeComponent();
            dataGridVentasMaderas.Columns[0].Visible = false;

            mostrarVentasMaderas();
        }

        public void mostrarVentasMaderas()
        {
            dataGridVentasMaderas.Rows.Clear();
            conexionBd = new Model1();

            var listarVentasRealizdasXabono = (from a in conexionBd.VentasSet where a.TipoPagoSet_IdTipoPago == 2 select a);

            foreach (VentasSet v in listarVentasRealizdasXabono)
            {
                //Darle formato a la fecha de registro
                var dateTime = v.FechaVenta;

                if (v.Deuda > 0)
                    dataGridVentasMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre + " " + v.ClientesSet.App + " " + v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.Deuda, "Abonar", "Ver abonos");
                else
                    dataGridVentasMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre + " " + v.ClientesSet.App + " " + v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.Deuda, "Pagado", "Ver abonos");

            }

        }

        private void texBoxCliente_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridVentasMaderas.Rows.Clear();
            conexionBd = new Model1();

            //Que me busque los registros de la tabla con lo que estan ingresando y que lo muestre siempre y cuando tengan el tipo de pago a credito
            var ventasEncontrados = (from c in conexionBd.VentasSet
                                      where ((c.ClientesSet.Nombre.Contains(texBoxCliente.Text) || c.ClientesSet.App.Contains(texBoxCliente.Text) || c.ClientesSet.Apm.Contains(texBoxCliente.Text)) && c.TipoPagoSet_IdTipoPago == 2)
                                      select c);

            if (ventasEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (VentasSet v in ventasEncontrados)
                {
                    var dateTime = v.FechaVenta;

                    if (v.Deuda > 0)
                        dataGridVentasMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre + " " + v.ClientesSet.App + " " + v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.Deuda, "Abonar", "Ver abonos");
                    else
                        dataGridVentasMaderas.Rows.Add(v.IdVenta, v.ClientesSet.Nombre + " " + v.ClientesSet.App + " " + v.ClientesSet.Apm, v.TipoPagoSet.Nombre, dateTime.ToShortDateString(), v.Deuda, "Pagado", "Ver abonos");
                }
            }
            else
            {
                lbrespuesta.Text = "No hay ventas de ese cliente";

                if (texBoxCliente.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridVentasMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridVentasMaderas.Rows.Count > 0)
            {
                //Realizar Abono
                if (e.ColumnIndex == 5)
                {

                    if (Convert.ToInt64(this.dataGridVentasMaderas.CurrentRow.Cells[4].Value) > 0)
                    {
                        int Idventa = Convert.ToInt32(this.dataGridVentasMaderas.CurrentRow.Cells[0].Value);

                        FormAgregarModificarAbonoClients formAgregarModificarAbonoClients = new FormAgregarModificarAbonoClients(Idventa);
                        formAgregarModificarAbonoClients.ShowDialog();
                        mostrarVentasMaderas();
                    }
                }
                else if (e.ColumnIndex == 6) //Cuando le dan clic en el boton de ver abonos
                {
                    int idVenta = Convert.ToInt32(this.dataGridVentasMaderas.CurrentRow.Cells[0].Value);

                    //Valido que existan abonos si no ando mensaje y no habro formulario
                    var listarAbonosrealizadosxVenta = (from a in conexionBd.RegistroAbonoClientesSet
                                                        where a.Ventas_IdVenta == idVenta
                                                        select a);

                    if (listarAbonosrealizadosxVenta.Count() > 0)
                    {
                        FormListarAbonosClientes formListarAbonosClientes = new FormListarAbonosClientes(idVenta);
                        formListarAbonosClientes.ShowDialog();
                        mostrarVentasMaderas();
                    }
                    else
                    {
                        MessageBox.Show("No hay ningun abono para revisar", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
