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
    public partial class FormDetallesVentaMaderas : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();

        Boolean boolGuardar;
        int idVenta = 0;

        //Estas variables las ocupo al darle cli en el dataGridListaMaderasAvenXcliente_CellDoubleClick
        long contadorCantidadTotal = 0;
        Double contadorTotalPrecio = 0;

        //guardarEditar,idVenta,nombreMadera,stock,precio
        public FormDetallesVentaMaderas(Boolean boolGuardar, int obtengoIdVenta)
        {
            InitializeComponent();

            dataGridDetalleVentaMaderas.Columns[0].Visible = false;
            dataGridDetalleVentaMaderas.Columns[7].Visible = false;
            dataGridListaMaderasAvenXcliente.Columns[0].Visible = false;

            //Llenado los comBoBox
            llenarComboClientes();
            llenarComboTipoPago();

        }

        private void llenarComboClientes()
        {
            List<ClientesSet> listaClientes = conexionBd.ClientesSet.ToList();

            if (listaClientes.Count > 0)
            {
                comboBoxCliente.DataSource = listaClientes;
                comboBoxCliente.ValueMember = "IdCliente";
                comboBoxCliente.DisplayMember = "nombre";
            }
        }

        private void llenarComboTipoPago()
        {
            List<TipoPagoSet> listaTipoPago = conexionBd.TipoPagoSet.ToList();

            if (listaTipoPago.Count > 0)
            {
                comboBoxTipoPago.DataSource = listaTipoPago;
                comboBoxTipoPago.ValueMember = "IdTipoPago";
                comboBoxTipoPago.DisplayMember = "nombre";
            }
        }

        public void mostrarListarMaderasAvender()
        {
            //Si no le pongo esto se van ir agregando registros al gridt en cada busqueda
            dataGridListaMaderasAvenXcliente.Rows.Clear();
            conexionBd = new Model1();

            //Obtengo el idClienteSelecionado en el combobox
            int idClienteComboBox = Convert.ToInt16(comboBoxCliente.SelectedValue.ToString());

            var listaMaderasAvenderPorClientectivados = (from a in conexionBd.PrecioVentaClienteSet
                                                         where a.Estatus == 1 && a.Clientes_IdCliente == idClienteComboBox
                                                         select a);

            if (listaMaderasAvenderPorClientectivados.Count() > 0)
            {
                foreach (PrecioVentaClienteSet m in listaMaderasAvenderPorClientectivados)
                {
                    dataGridListaMaderasAvenXcliente.Rows.Add(m.IdPrecioVcm, m.MaderasSet.Nombre, m.MaderasSet.Descripcion);
                }
                textBoxCantidad.Focus();
            }
            else
            {
                MessageBox.Show("No se encontraron registros"," ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
               
        }

        private void pasandoNombreCliente(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((ClientesSet)e.ListItem).Nombre;
            string app = ((ClientesSet)e.ListItem).App;
            string apm = ((ClientesSet)e.ListItem).Apm;

            e.Value = nombre + " " + app + " " + apm;
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vaciando los dataGri al seleccionar algo en los comboBox
            dataGridListaMaderasAvenXcliente.Rows.Clear();
            dataGridDetalleVentaMaderas.Rows.Clear();

            //Estas variables globales inicializarlas nuevamnet para que no haga mal la operacion
            contadorCantidadTotal = 0;
            contadorTotalPrecio = 0;

            textBoxCantidad.Text = "";
            buttonBuscarMaderaVender.Enabled = true;
        }


        private void buttonBuscarMaderaVender_Click(object sender, EventArgs e)
        {
            //SelectedValue----Te obtiene el valor de los id que le estas pasando de tu base de datos-------Es de tipo String
            //ValueMember---Te obtiene solo un texto no valor "idCliente"   ----- Es de tipo String
            //SelectedIndex---Te obtiene el indice del selector inicia en el 0 hasta el infinito------int


            //Ejecutar este metodo para mostrar las maderas y su precio deaucerdo al cliente
            mostrarListarMaderasAvender();
            buttonBuscarMaderaVender.Enabled = false;
        }

        private void dataGridListaMaderasAvenXcliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridListaMaderasAvenXcliente.Rows.Count > 0)
            {
                if (textBoxCantidad.Text != "")
                {
                    //Obtengo el idRegistro
                    int IdPrecioVcm = Convert.ToInt32(this.dataGridListaMaderasAvenXcliente.CurrentRow.Cells[0].Value);

                    var buscarMaderaAVender = (from a in conexionBd.PrecioVentaClienteSet
                                               where a.Estatus == 1 && a.IdPrecioVcm == IdPrecioVcm
                                               select a);

                    Boolean bandera = false;
                    foreach (PrecioVentaClienteSet m in buscarMaderaAVender)
                    {

                        if ((m.MaderasSet.Stock >= Convert.ToInt64(textBoxCantidad.Text.ToString())))
                        {
                            //REALIZANDO EL CALCULO TOTAL DE LA VENTA
                            contadorCantidadTotal = contadorCantidadTotal + Convert.ToInt64(textBoxCantidad.Text.ToString());
                            textBoxCantidadTotal.Text = contadorCantidadTotal.ToString();

                            Double calculaSubtotal = Convert.ToDouble(textBoxCantidad.Text.ToString()) * m.PrecioMadera;

                            dataGridDetalleVentaMaderas.Rows.Add(m.IdPrecioVcm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, m.MaderasSet.Stock, m.PrecioMadera, Convert.ToInt64(textBoxCantidad.Text.ToString()), calculaSubtotal, "Quitar",m.Maderas_IdMadera);
                            //Sigue otro proceso
                            bandera = true;
                            textBoxCantidad.Text = "";
                            dataGridListaMaderasAvenXcliente.Rows.RemoveAt(e.RowIndex); //Elimina el registro para que no lo vuelva a elejir


                            //REALIZANDO EL CALCULO TOTAL DE LA VENTA
                            contadorTotalPrecio = contadorTotalPrecio + calculaSubtotal;
                            textBoxTotal.Text = contadorTotalPrecio.ToString();
                            break;
                        }
                    }

                    if (!bandera)
                    {
                        MessageBox.Show("No cuentas con esa cantidada para vender en existencia", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxCantidad.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Debe agregar la cantidad a vender", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCantidad.Focus();
                }
            }
        }

        private void dataGridDetalleVentaMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridDetalleVentaMaderas.Rows.Count > 0)
            {
                
                if (e.ColumnIndex == 6)
                {

                    int IdPrecioVc = Convert.ToInt32(this.dataGridDetalleVentaMaderas.CurrentRow.Cells[0].Value);

                    var buscarMaderaAVender = (from a in conexionBd.PrecioVentaClienteSet
                                               where a.Estatus == 1 && a.IdPrecioVcm == IdPrecioVc
                                               select a);
                    
                    foreach (PrecioVentaClienteSet m in buscarMaderaAVender)
                    {
                        //Paso al dataGrid el registro que se esta quitando
                        dataGridListaMaderasAvenXcliente.Rows.Add(m.IdPrecioVcm, m.MaderasSet.Nombre, m.MaderasSet.Descripcion);

                        //REALIZANDO EL CALCULO TOTAL DE LA VENTA QUE SE QUITA
                        contadorCantidadTotal = contadorCantidadTotal - Convert.ToInt64(this.dataGridDetalleVentaMaderas.CurrentRow.Cells[4].Value);
                        textBoxCantidadTotal.Text = contadorCantidadTotal.ToString();

                        //REALIZANDO EL CALCULO TOTAL DE LA VENTA QUE SE QUITA
                        contadorTotalPrecio = contadorTotalPrecio - Convert.ToDouble(this.dataGridDetalleVentaMaderas.CurrentRow.Cells[5].Value);
                        textBoxTotal.Text = contadorTotalPrecio.ToString();

                        //Quito el registro del dataGrid
                        dataGridDetalleVentaMaderas.Rows.RemoveAt(e.RowIndex);
                        break;
                    }

                }
                    
                    
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Agregar nueva venta
            if (boolGuardar == false)
            {

                if (dataGridDetalleVentaMaderas.Rows.Count > 0) {

                    if (textBoxRealizaVenta.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el nombre de quien entrega la venta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxRealizaVenta.Focus();
                    }else if (textBoxRecibe.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el nombre de quien recibe la venta", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxRecibe.Focus();
                    }else if (textBoxPagaCon.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el pago", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxPagaCon.Focus();

                    }
                    else if(Convert.ToDouble(textBoxPagaCon.Text.ToString()) > Convert.ToDouble(textBoxTotal.Text.ToString()))
                    {
                        MessageBox.Show("Rectifica el pago, no es justo", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxPagaCon.Focus();
                    }
                    else
                    {
                        //VALIDAR SI VENTA DE CONTADO QUE LIQUIDE LA VENTA CON EL PRECIO TOTAL
                        //Obtengo el idIdTipoPago en el combobox
                        int idIdTipoPago = Convert.ToInt16(comboBoxTipoPago.SelectedValue.ToString());

                        //VENTA DE CONTADO
                        if (idIdTipoPago == 1)
                        {
                            if (Convert.ToDouble(textBoxPagaCon.Text.ToString()) != Convert.ToDouble(textBoxTotal.Text.ToString()))
                            {
                                MessageBox.Show("Debe liquidar el pago total, por que esta vendiendo al contado", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBoxPagaCon.Focus();
                            }
                            else
                            {
                                VentasSet nuevaVenta = new VentasSet();
                                int idContador = 0;

                                //DateTime fechaVenta = DateTime.Now;
                                var obtengoTamanoRegistros = (from a in conexionBd.VentasSet select a);
                                idContador = obtengoTamanoRegistros.Count() + 1;

                                nuevaVenta.IdVenta = idContador;
                                nuevaVenta.FechaVenta = Convert.ToDateTime(dateTimeFechaVenta.Text);
                                nuevaVenta.TotalProducto = Convert.ToInt64(textBoxCantidadTotal.Text.ToString());
                                nuevaVenta.PrecioTotal = Convert.ToDouble(textBoxTotal.Text.ToString());

                                //Obtener la fecha actual
                                DateTime fechaActual = DateTime.Now;
                                nuevaVenta.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                                nuevaVenta.PagoCon = Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                nuevaVenta.Deuda = Convert.ToDouble(textBoxTotal.Text.ToString()) - Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                nuevaVenta.ClientesSet_IdCliente = Convert.ToInt32(comboBoxCliente.SelectedValue.ToString());

                                nuevaVenta.TipoPagoSet_IdTipoPago = Convert.ToInt32(comboBoxTipoPago.SelectedValue.ToString());

                                nuevaVenta.NombreEntrega = textBoxRealizaVenta.Text.ToString();

                                nuevaVenta.NombreRecibe = textBoxRecibe.Text.ToString();


                                conexionBd.VentasSet.Add(nuevaVenta);
                                conexionBd.SaveChanges();


                                //Gauardar detalleVenta----Recorro con un ciclo los registros de grid y los almaceno a la tabla
                                for (int i = 0; i < dataGridDetalleVentaMaderas.Rows.Count; i++)
                                {
                                    DetalleVentasSet agregandoProductoAventa = new DetalleVentasSet();

                                    agregandoProductoAventa.Cantidad = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[4].Value);
                                    agregandoProductoAventa.SubTotal = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[5].Value);
                                    agregandoProductoAventa.Ventas_IdVenta = idContador;
                                    agregandoProductoAventa.PrecioVentaClienteSet_IdPrecioVcm = Convert.ToInt32(this.dataGridDetalleVentaMaderas.Rows[i].Cells[0].Value);
                                    conexionBd.DetalleVentasSet.Add(agregandoProductoAventa);
                                    conexionBd.SaveChanges();

                                    //ACTUALIZAR EL STOCK DE LA TABLA DESDE AQUI; SI SE AGREGA A LA VENTA
                                    int idMadera = 0;
                                    idMadera = Convert.ToInt32(this.dataGridDetalleVentaMaderas.Rows[i].Cells[7].Value);

                                    MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();

                                    long actualizaStockBd = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[2].Value) - Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[4].Value);
                                    maderaEncontrado.Stock = Convert.ToInt64(actualizaStockBd);
                                    conexionBd.SaveChanges();

                                }

                                this.Close();
                            }
                        }//VENTA POR ABONOS
                        else
                        {
                            VentasSet nuevaVenta = new VentasSet();
                            int idContador = 0;

                            //DateTime fechaVenta = DateTime.Now;
                            var obtengoTamanoRegistros = (from a in conexionBd.VentasSet select a);
                            idContador = obtengoTamanoRegistros.Count() + 1;

                            nuevaVenta.IdVenta = idContador;
                            nuevaVenta.FechaVenta = Convert.ToDateTime(dateTimeFechaVenta.Text);
                            nuevaVenta.TotalProducto = Convert.ToInt64(textBoxCantidadTotal.Text.ToString());
                            nuevaVenta.PrecioTotal = Convert.ToDouble(textBoxTotal.Text.ToString());

                            //Obtener la fecha actual
                            DateTime fechaActual = DateTime.Now;
                            nuevaVenta.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                            nuevaVenta.PagoCon = Convert.ToDouble(textBoxPagaCon.Text.ToString());

                            nuevaVenta.Deuda = Convert.ToDouble(textBoxTotal.Text.ToString()) - Convert.ToDouble(textBoxPagaCon.Text.ToString());

                            nuevaVenta.ClientesSet_IdCliente = Convert.ToInt32(comboBoxCliente.SelectedValue.ToString());

                            nuevaVenta.TipoPagoSet_IdTipoPago = Convert.ToInt32(comboBoxTipoPago.SelectedValue.ToString());

                            nuevaVenta.NombreEntrega = textBoxRealizaVenta.Text.ToString();

                            nuevaVenta.NombreRecibe = textBoxRecibe.Text.ToString();


                            conexionBd.VentasSet.Add(nuevaVenta);
                            conexionBd.SaveChanges();


                            //Gauardar detalleVenta----Recorro con un ciclo los registros de grid y los almaceno a la tabla
                            for (int i = 0; i < dataGridDetalleVentaMaderas.Rows.Count; i++)
                            {
                                DetalleVentasSet agregandoProductoAventa = new DetalleVentasSet();

                                agregandoProductoAventa.Cantidad = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[4].Value);
                                agregandoProductoAventa.SubTotal = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[5].Value);
                                agregandoProductoAventa.Ventas_IdVenta = idContador;
                                agregandoProductoAventa.PrecioVentaClienteSet_IdPrecioVcm = Convert.ToInt32(this.dataGridDetalleVentaMaderas.Rows[i].Cells[0].Value);
                                conexionBd.DetalleVentasSet.Add(agregandoProductoAventa);
                                conexionBd.SaveChanges();

                                //ACTUALIZAR EL STOCK DE LA TABLA DESDE AQUI; SI SE AGREGA A LA VENTA
                                int idMadera = 0;
                                idMadera = Convert.ToInt32(this.dataGridDetalleVentaMaderas.Rows[i].Cells[7].Value);

                                MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();

                                long actualizaStockBd = Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[2].Value) - Convert.ToInt64(this.dataGridDetalleVentaMaderas.Rows[i].Cells[4].Value);
                                maderaEncontrado.Stock = Convert.ToInt64(actualizaStockBd);
                                conexionBd.SaveChanges();

                            }

                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar las maderas para vender", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCantidad.Focus();
                }

            }
        }

        private void textBoxPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales.aceptasolonumerodecimal(sender, e, ('.'));
        }
    }
}

