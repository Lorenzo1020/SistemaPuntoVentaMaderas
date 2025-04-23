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
    public partial class FormListarAbonosProved : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        int idCompra = 0;

        public FormListarAbonosProved(int idCompra)
        {
            InitializeComponent();
            //Acacho el idCompra para buscar los abonos de esta compra 
            this.idCompra = idCompra;

            dataGridAbonoProveedorCompras.Columns[0].Visible = false;
            dataGridAbonoProveedorCompras.Columns[6].Visible = false;

            mostraAbonosProveedorCompras();
        }


        public void mostraAbonosProveedorCompras()
        {
            dataGridAbonoProveedorCompras.Rows.Clear();
            conexionBd = new Model1();

            var listarAbonosrealizadosxCompra = (from a in conexionBd.RegistroAbonoProveedorSet
                                                 where a.Compras_IdCompra == idCompra
                                                 select a);

            String provedor = "";
            foreach (RegistroAbonoProveedorSet b in listarAbonosrealizadosxCompra)
            {
                //Darle formato a la fecha de registro
                var dateTime = b.FechaAbono;
                provedor = b.ComprasSet.ProveedoresSet.Nombre + " " + b.ComprasSet.ProveedoresSet.App + " " + b.ComprasSet.ProveedoresSet.Apm;

                dataGridAbonoProveedorCompras.Rows.Add(b.IdAbono, dateTime.ToShortDateString(), b.Debia, b.Abono, b.Debe, b.RecibeAbono, b.Compras_IdCompra);

            }

            textBoxProvedor.Text = provedor;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            long indiceFilaSeleccionada = dataGridAbonoProveedorCompras.CurrentCell.RowIndex + 1;

            //Comparo si para saber si selecciono el ultimo registro
            if (indiceFilaSeleccionada == dataGridAbonoProveedorCompras.Rows.Count)
            {
                //Se cancela el abono

                //Busco el registro por idCompra y actualizo el registro----en la tabla compras: el campo deuda
                int idCompraProvedor = Convert.ToInt32(this.dataGridAbonoProveedorCompras.CurrentRow.Cells[6].Value);

                ComprasSet compraEncontrado = conexionBd.ComprasSet.Where(x => x.IdCompra == idCompraProvedor).Select(x => x).FirstOrDefault();

                compraEncontrado.Deuda = compraEncontrado.Deuda + Convert.ToInt32(this.dataGridAbonoProveedorCompras.CurrentRow.Cells[3].Value);
                //Actualizacion del registro
                conexionBd.SaveChanges();

                //Busco el registro por idAbono y Elimino el registro de la tabla abono
                int idAbono = Convert.ToInt32(this.dataGridAbonoProveedorCompras.CurrentRow.Cells[0].Value);

                RegistroAbonoProveedorSet abonoEncontrado = conexionBd.RegistroAbonoProveedorSet.Where(x => x.IdAbono == idAbono).Select(x => x).FirstOrDefault();
                //Elimino el registro encontrado
                conexionBd.RegistroAbonoProveedorSet.Remove(abonoEncontrado);
                conexionBd.SaveChanges();

                this.Close();

            }
        }
    }
}
