using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoVentaMaderas.View;
using SistemaPuntoVentaMaderas.Models;

namespace SistemaPuntoVentaMaderas
{
    public partial class FormAbonosProveedores : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();

        public FormAbonosProveedores()
        {
            InitializeComponent();
            dataGridComprasMaderas.Columns[0].Visible = false;

            mostrarComprasMaderas();
        }


        public void mostrarComprasMaderas()
        {
            dataGridComprasMaderas.Rows.Clear();
            conexionBd = new Model1();

            var listarComprasRealizdasXabono = (from a in conexionBd.ComprasSet where a.TipoPago_IdTipoPago == 2  select a);

            foreach (ComprasSet c in listarComprasRealizdasXabono)
            {
                //Darle formato a la fecha de registro
                var dateTime = c.FechaCompra;

                if (c.Deuda > 0)
                    dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.Deuda, "Abonar", "Ver abonos");
                else
                    dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.Deuda, "Pagado", "Ver abonos");

            }

        }

        private void texBoxProvedor_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridComprasMaderas.Rows.Clear();
            conexionBd = new Model1();

            //Que me busque los registros de la tabla con lo que estan ingresando y que lo muestre siempre y cuando tengan el tipo de pago a credito
            var comprasEncontrados = (from c in conexionBd.ComprasSet
                                     where ((c.ProveedoresSet.Nombre.Contains(texBoxProvedor.Text) || c.ProveedoresSet.App.Contains(texBoxProvedor.Text) || c.ProveedoresSet.Apm.Contains(texBoxProvedor.Text)) && c.TipoPago_IdTipoPago == 2)
                                     select c);

            if (comprasEncontrados.Count() > 0)
            {
                lbrespuesta.Text = "";

                foreach (ComprasSet c in comprasEncontrados)
                {
                    var dateTime = c.FechaCompra;

                    if (c.Deuda > 0)
                        dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.Deuda, "Abonar", "Ver abonos");
                    else
                        dataGridComprasMaderas.Rows.Add(c.IdCompra, c.ProveedoresSet.Nombre + " " + c.ProveedoresSet.App + " " + c.ProveedoresSet.Apm, c.TipoPagoSet.Nombre, dateTime.ToShortDateString(), c.Deuda, "Pagado", "Ver abonos");
                }
            }
            else
            {
                lbrespuesta.Text = "No hay compras de ese proveedor";

                if (texBoxProvedor.Text == "")
                {
                    lbrespuesta.Text = "";
                }
            }
        }

        private void dataGridComprasMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridComprasMaderas.Rows.Count > 0)
            {
                //Realizar Abono
                if (e.ColumnIndex == 5)
                {

                    if (Convert.ToInt64(this.dataGridComprasMaderas.CurrentRow.Cells[4].Value) > 0)
                    {
                        int IdCompra = Convert.ToInt32(this.dataGridComprasMaderas.CurrentRow.Cells[0].Value);

                        FormAgregarModificarAbonoProveds formAgregarModificarAbono = new FormAgregarModificarAbonoProveds(IdCompra);
                        formAgregarModificarAbono.ShowDialog();
                        mostrarComprasMaderas();
                    }
                }
                else if (e.ColumnIndex == 6) //Cuando le dan clic en el boton de ver abonos
                {
                    int idCompra = Convert.ToInt32(this.dataGridComprasMaderas.CurrentRow.Cells[0].Value);

                    //Valido que existan abonos si no ando mensaje y no habro formulario
                    var listarAbonosrealizadosxCompra = (from a in conexionBd.RegistroAbonoProveedorSet
                                                         where a.Compras_IdCompra == idCompra
                                                         select a);

                    if (listarAbonosrealizadosxCompra.Count() > 0)
                    {
                        FormListarAbonosProved formListarAbonos = new FormListarAbonosProved(idCompra);
                        formListarAbonos.ShowDialog();
                        mostrarComprasMaderas();
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
