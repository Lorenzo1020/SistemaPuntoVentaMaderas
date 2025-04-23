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
    public partial class FormListarAbonosClientes : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        int idVenta = 0;

        public FormListarAbonosClientes(int idVenta)
        {
            InitializeComponent();
            //Acacho el idCompra para buscar los abonos de esta compra 
            this.idVenta = idVenta;

            dataGridAbonoClientesVentas.Columns[0].Visible = false;
            dataGridAbonoClientesVentas.Columns[6].Visible = false;


            mostraAbonosClientesVentas();
        }


        public void mostraAbonosClientesVentas()
        {
            dataGridAbonoClientesVentas.Rows.Clear();
            conexionBd = new Model1();

            var listarAbonosrealizadosxVenta = (from a in conexionBd.RegistroAbonoClientesSet
                                                 where a.Ventas_IdVenta == idVenta
                                                 select a);

            String cliente = "";
            foreach (RegistroAbonoClientesSet b in listarAbonosrealizadosxVenta)
            {
                //Darle formato a la fecha de registro
                var dateTime = b.FechaAbono;
                cliente = b.VentasSet.ClientesSet.Nombre + " " + b.VentasSet.ClientesSet.App + " " + b.VentasSet.ClientesSet.Apm;

                dataGridAbonoClientesVentas.Rows.Add(b.IdAbono, dateTime.ToShortDateString(), b.Debia, b.Abono, b.Debe, b.RecibeAbono, b.Ventas_IdVenta);

            }

            textBoxCliente.Text = cliente;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            long indiceFilaSeleccionada = dataGridAbonoClientesVentas.CurrentCell.RowIndex + 1;

            //Comparo si para saber si selecciono el ultimo registro
            if (indiceFilaSeleccionada == dataGridAbonoClientesVentas.Rows.Count)
            {
                //Se cancela el abono

                //Busco el registro por idCompra y actualizo el registro----en la tabla compras: el campo deuda
                int idCompraCliente = Convert.ToInt32(this.dataGridAbonoClientesVentas.CurrentRow.Cells[6].Value);

                VentasSet compraEncontrado = conexionBd.VentasSet.Where(x => x.IdVenta == idCompraCliente).Select(x => x).FirstOrDefault();

                compraEncontrado.Deuda = compraEncontrado.Deuda + Convert.ToInt32(this.dataGridAbonoClientesVentas.CurrentRow.Cells[3].Value);
                //Actualizacion del registro
                conexionBd.SaveChanges();

                //Busco el registro por idAbono y Elimino el registro de la tabla abono
                int idAbono = Convert.ToInt32(this.dataGridAbonoClientesVentas.CurrentRow.Cells[0].Value);

                RegistroAbonoClientesSet abonoEncontrado = conexionBd.RegistroAbonoClientesSet.Where(x => x.IdAbono == idAbono).Select(x => x).FirstOrDefault();
                //Elimino el registro encontrado
                conexionBd.RegistroAbonoClientesSet.Remove(abonoEncontrado);
                conexionBd.SaveChanges();

                this.Close();

            }
        }
    }
}
