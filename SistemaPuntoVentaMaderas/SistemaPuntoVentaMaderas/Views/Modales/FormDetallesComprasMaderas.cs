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
    public partial class FormDetallesComprasMaderas : Form
    {
        //Variables globales
        Model1 conexionBd = new Model1();
        Boolean boolGuardar;
        int idCompra = 0;

        //Estas variables las ocupo al darle cli en el dataGridListaMaderasAvenXcliente_CellDoubleClick
        long contadorCantidadTotal = 0;
        Double contadorTotalPrecio = 0;

        public FormDetallesComprasMaderas(Boolean boolGuardar, int idCompra)
        {
            InitializeComponent();

            //Al cargar el formulario se ejecuta esto para ver si es agregar o cancelar
            this.boolGuardar = boolGuardar;
            this.idCompra = idCompra;

            dataGridDetalleComprasMaderas.Columns[0].Visible = false;
            dataGridDetalleComprasMaderas.Columns[7].Visible = false;
            dataGridDetalleComprasMaderas.Columns[8].Visible = false;
            dataGridListaMaderasAComprarXproved.Columns[0].Visible = false;
            dataGridDetalleComprasMaderas.Columns[1].Width = 200;

            llenarComboProvedor();
            llenarComboTipoPago();


            //Si ya existe ese registro de compra muestro los datos en el formulario
            if (boolGuardar == true)
            {
                btnAlta.Text = "Cancelar compra";
                labelProveedor.Enabled=false;
                buttonBuscarMaderaComprar.Enabled = false;
                labelCantidadComprar.Enabled = false;
                textBoxCantidad.Enabled = false;
                labelTipoPago.Enabled = false;
                labelFechaCompra.Enabled = false;
                comboBoxProveedor.Enabled = false;
                comboBoxTipoPago.Enabled = false;
                dateTimeFechaCompra.Enabled = false;
                textBoxPagaCon.Enabled = false;
                textBoxRealizaCompra.Enabled = false;
                textBoxRecibe.Enabled = false;
                dataGridDetalleComprasMaderas.Enabled = false;
                dataGridListaMaderasAComprarXproved.Enabled = false;
                dataGridDetalleComprasMaderas.Columns[6].Visible = false;

                var detalleCompraEncontrado = (from a in conexionBd.DetalleComprasSet
                                               where a.Compras_IdCompra == idCompra
                                               select a);

                foreach (DetalleComprasSet dc in detalleCompraEncontrado)
                {
                    comboBoxProveedor.SelectedValue = dc.ComprasSet.Proveedores_IdProveedor;
                    comboBoxTipoPago.SelectedValue = dc.ComprasSet.TipoPago_IdTipoPago;
                    dateTimeFechaCompra.Text = dc.ComprasSet.FechaCompra.ToString();
                    textBoxRealizaCompra.Text = dc.ComprasSet.NombreEntrega;
                    textBoxRecibe.Text = dc.ComprasSet.NombreRecibe;
                    textBoxCantidadTotal.Text = dc.ComprasSet.TotalProducto.ToString();
                    textBoxPrecioTotal.Text = dc.ComprasSet.PrecioTotal.ToString();
                    textBoxPagaCon.Text = dc.ComprasSet.PagoCon.ToString();

                    //Mostrar los productos de la venta guardada
                    dataGridDetalleComprasMaderas.Rows.Add(dc.PrecioCompraProveedorSet_IdPrecioCpm, dc.PrecioCompraProveedorSet.MaderasSet.Nombre + " " + dc.PrecioCompraProveedorSet.MaderasSet.Descripcion, dc.PrecioCompraProveedorSet.MaderasSet.Stock, dc.PrecioCompraProveedorSet.PrecioMadera, dc.Cantidad, dc.Subtotal, "Cancelar", dc.PrecioCompraProveedorSet.Maderas_IdMadera, dc.IdDetalleCompra);
                }
            }
        }



        private void llenarComboProvedor()
        {
            List<ProveedoresSet> listaProvedores = conexionBd.ProveedoresSet.ToList();

            if (listaProvedores.Count > 0)
            {
                comboBoxProveedor.DataSource = listaProvedores;
                comboBoxProveedor.ValueMember = "IdProveedor";
                comboBoxProveedor.DisplayMember = "nombre";
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

        public void mostrarListarMaderasAcomprar()
        {
            //Si no le pongo esto se van ir agregando registros al gridt en cada busqueda
            dataGridListaMaderasAComprarXproved.Rows.Clear();
            conexionBd = new Model1();

            //Obtengo el idPeovedSelecionado en el combobox
            int idProvedComboBox = Convert.ToInt16(comboBoxProveedor.SelectedValue.ToString());

            var listaMaderasAcomprarPorClientectivados = (from a in conexionBd.PrecioCompraProveedorSet
                                                         where a.Estatus == 1 && a.Proveedores_IdProveedor == idProvedComboBox
                                                          select a);

            if (listaMaderasAcomprarPorClientectivados.Count() > 0)
            {
                foreach (PrecioCompraProveedorSet m in listaMaderasAcomprarPorClientectivados)
                {
                    dataGridListaMaderasAComprarXproved.Rows.Add(m.IdPrecioCpm, m.MaderasSet.Nombre, m.MaderasSet.Descripcion);
                }
                textBoxCantidad.Focus();
            }
            else
            {
                MessageBox.Show("No se encontraron registros", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void pasandoNombreProvedor(object sender, ListControlConvertEventArgs e)
        {
            // Suponiendo que su clase se llama Empleado, y Nombre y Apellido son los campos
            string nombre = ((ProveedoresSet)e.ListItem).Nombre;
            string app = ((ProveedoresSet)e.ListItem).App;
            string apm = ((ProveedoresSet)e.ListItem).Apm;

            e.Value = nombre + " " + app + " " + apm;
        }

        private void comboBoxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vaciando los dataGri al seleccionar algo en los comboBox
            dataGridListaMaderasAComprarXproved.Rows.Clear();
            dataGridDetalleComprasMaderas.Rows.Clear();
            //Estas variables globales inicializarlas nuevamnet para que no haga mal la operacion
            contadorCantidadTotal = 0;
            contadorTotalPrecio = 0;

            textBoxCantidad.Text = "";
            buttonBuscarMaderaComprar.Enabled = true;
        }

        private void buttonBuscarMaderaVender_Click(object sender, EventArgs e)
        {
            //Ejecutar este metodo para mostrar las maderas y su precio deaucerdo al provedor
            mostrarListarMaderasAcomprar();
            buttonBuscarMaderaComprar.Enabled = false;
        }

        private void dataGridListaMaderasAComprarXproved_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridListaMaderasAComprarXproved.Rows.Count > 0)
            {
                if (textBoxCantidad.Text != "")
                {
                    //Obtengo el idRegistro
                    int IdPrecioCpm = Convert.ToInt32(this.dataGridListaMaderasAComprarXproved.CurrentRow.Cells[0].Value);

                    var buscarMaderaComprar = (from a in conexionBd.PrecioCompraProveedorSet
                                               where a.Estatus == 1 && a.IdPrecioCpm == IdPrecioCpm
                                               select a);

                    foreach (PrecioCompraProveedorSet m in buscarMaderaComprar)
                    {
                        //REALIZANDO EL CALCULO TOTAL DE LA COMPRA
                        contadorCantidadTotal = contadorCantidadTotal + Convert.ToInt64(textBoxCantidad.Text.ToString());
                        textBoxCantidadTotal.Text = contadorCantidadTotal.ToString();

                        Double calculaSubtotal = Convert.ToDouble(textBoxCantidad.Text.ToString()) * m.PrecioMadera;

                        dataGridDetalleComprasMaderas.Rows.Add(m.IdPrecioCpm, m.MaderasSet.Nombre + " " + m.MaderasSet.Descripcion, m.MaderasSet.Stock, m.PrecioMadera, Convert.ToInt64(textBoxCantidad.Text.ToString()), calculaSubtotal, "Quitar", m.Maderas_IdMadera);

                        //Sigue otro proceso
                        textBoxCantidad.Text = "";
                        dataGridListaMaderasAComprarXproved.Rows.RemoveAt(e.RowIndex); //Elimina el registro para que no lo vuelva a elejir


                        //REALIZANDO EL CALCULO TOTAL DE LA COMPRA
                        contadorTotalPrecio = contadorTotalPrecio + calculaSubtotal;
                        textBoxPrecioTotal.Text = contadorTotalPrecio.ToString();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar la cantidad a comprar", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCantidad.Focus();
                }
            }
        }

        private void dataGridDetalleComprasMaderas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridDetalleComprasMaderas.Rows.Count > 0)
            {

                if (e.ColumnIndex == 6)
                {

                    int IdPrecioCpm = Convert.ToInt32(this.dataGridDetalleComprasMaderas.CurrentRow.Cells[0].Value);

                    var buscarMaderaAcomprar = (from a in conexionBd.PrecioCompraProveedorSet
                                               where a.Estatus == 1 && a.IdPrecioCpm == IdPrecioCpm
                                                select a);

                    foreach (PrecioCompraProveedorSet m in buscarMaderaAcomprar)
                    {
                        //Paso al dataGrid el registro que se esta quitando
                        dataGridListaMaderasAComprarXproved.Rows.Add(m.IdPrecioCpm, m.MaderasSet.Nombre, m.MaderasSet.Descripcion);

                        //REALIZANDO EL CALCULO TOTAL DE LA COMPRA QUE SE QUITA
                        contadorCantidadTotal = contadorCantidadTotal - Convert.ToInt64(this.dataGridDetalleComprasMaderas.CurrentRow.Cells[4].Value);
                        textBoxCantidadTotal.Text = contadorCantidadTotal.ToString();

                        //REALIZANDO EL CALCULO TOTAL DE LA COMPRA QUE SE QUITA
                        contadorTotalPrecio = contadorTotalPrecio - Convert.ToDouble(this.dataGridDetalleComprasMaderas.CurrentRow.Cells[5].Value);
                        textBoxPrecioTotal.Text = contadorTotalPrecio.ToString();

                        //Quito el registro del dataGrid
                        dataGridDetalleComprasMaderas.Rows.RemoveAt(e.RowIndex);
                        break;
                    }

                }


            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //Agregar nueva compra
            if (boolGuardar == false)
            {

                if (dataGridDetalleComprasMaderas.Rows.Count > 0)
                {

                    if (textBoxRealizaCompra.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el nombre de quien entrega la compra", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxRealizaCompra.Focus();
                    }
                    else if (textBoxRecibe.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el nombre de quien recibe la compra", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxRecibe.Focus();
                    }
                    else if (textBoxPagaCon.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el pago", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxPagaCon.Focus();

                    }
                    else if (Convert.ToDouble(textBoxPagaCon.Text.ToString()) > Convert.ToDouble(textBoxPrecioTotal.Text.ToString()))
                    {
                        MessageBox.Show("Rectifica el pago, no es justo", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxPagaCon.Focus();
                    }
                    else
                    {
                        //VALIDAR SI COMPRA DE CONTADO QUE LIQUIDE LA COMPRA CON EL PRECIO TOTAL
                        //Obtengo el idIdTipoPago en el combobox
                        int idIdTipoPago = Convert.ToInt16(comboBoxTipoPago.SelectedValue.ToString());

                        //COMPRO DE CONTADO
                        if (idIdTipoPago == 1)
                        {
                            if (Convert.ToDouble(textBoxPagaCon.Text.ToString()) != Convert.ToDouble(textBoxPrecioTotal.Text.ToString()))
                            {
                                MessageBox.Show("Debe liquidar el pago total, por que esta comprando al contado", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBoxPagaCon.Focus();
                            }
                            else
                            {
                                if (MessageBox.Show("¿Esta seguro que la información de la compra es correcto?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    ComprasSet nuevaCompra = new ComprasSet();
                                    int idContador = 0;

                                    //cuento los registros que hay en la tabla para que se genere el numero de compra
                                    var obtengoTamanoRegistros = (from a in conexionBd.ComprasSet select a);
                                    idContador = obtengoTamanoRegistros.Count() + 1;

                                    nuevaCompra.IdCompra = idContador;
                                    nuevaCompra.FechaCompra = Convert.ToDateTime(dateTimeFechaCompra.Text);
                                    nuevaCompra.TotalProducto = Convert.ToInt64(textBoxCantidadTotal.Text.ToString());
                                    nuevaCompra.PrecioTotal = Convert.ToDouble(textBoxPrecioTotal.Text.ToString());

                                    //Obtener la fecha actual
                                    DateTime fechaActual = DateTime.Now;
                                    nuevaCompra.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                                    nuevaCompra.PagoCon = Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                    nuevaCompra.Deuda = Convert.ToDouble(textBoxPrecioTotal.Text.ToString()) - Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                    nuevaCompra.Proveedores_IdProveedor = Convert.ToInt32(comboBoxProveedor.SelectedValue.ToString());

                                    nuevaCompra.TipoPago_IdTipoPago = Convert.ToInt32(comboBoxTipoPago.SelectedValue.ToString());

                                    nuevaCompra.NombreEntrega = textBoxRealizaCompra.Text.ToString();

                                    nuevaCompra.NombreRecibe = textBoxRecibe.Text.ToString();

                                    conexionBd.ComprasSet.Add(nuevaCompra);
                                    conexionBd.SaveChanges();


                                    //Gauardar detalleCompra----Recorro con un ciclo los registros de grid y los almaceno a la tabla
                                    for (int i = 0; i < dataGridDetalleComprasMaderas.Rows.Count; i++)
                                    {
                                        DetalleComprasSet agregandoProductoCompra = new DetalleComprasSet();

                                        agregandoProductoCompra.Cantidad = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[4].Value);
                                        agregandoProductoCompra.Subtotal = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[5].Value);
                                        agregandoProductoCompra.Compras_IdCompra = idContador;
                                        agregandoProductoCompra.PrecioCompraProveedorSet_IdPrecioCpm = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[0].Value);
                                        conexionBd.DetalleComprasSet.Add(agregandoProductoCompra);
                                        conexionBd.SaveChanges();

                                        //ACTUALIZAR EL STOCK DE LA TABLA DESDE AQUI; SI SE AGREGA A LA COMPRA
                                        int idMadera = 0;
                                        idMadera = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[7].Value);

                                        MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();

                                        long actualizaStockBd = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[2].Value) + Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[4].Value);
                                        maderaEncontrado.Stock = Convert.ToInt64(actualizaStockBd);
                                        conexionBd.SaveChanges();

                                    }
                                    this.Close();
                                }
                            }

                        }//COMPRO POR ABONOS
                        else
                        {
                            if (MessageBox.Show("¿Esta seguro que la información de la compra es correcto?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ComprasSet nuevaCompra = new ComprasSet();
                                int idContador = 0;

                                //cuento los registros que hay en la tabla para que se genere el numero de compra
                                var obtengoTamanoRegistros = (from a in conexionBd.ComprasSet select a);
                                idContador = obtengoTamanoRegistros.Count() + 1;

                                nuevaCompra.IdCompra = idContador;
                                nuevaCompra.FechaCompra = Convert.ToDateTime(dateTimeFechaCompra.Text);
                                nuevaCompra.TotalProducto = Convert.ToInt64(textBoxCantidadTotal.Text.ToString());
                                nuevaCompra.PrecioTotal = Convert.ToDouble(textBoxPrecioTotal.Text.ToString());

                                //Obtener la fecha actual
                                DateTime fechaActual = DateTime.Now;
                                nuevaCompra.FechaRegistro = Convert.ToDateTime(fechaActual.ToString("yyyy/MM/dd 00:00:00.00"));

                                nuevaCompra.PagoCon = Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                nuevaCompra.Deuda = Convert.ToDouble(textBoxPrecioTotal.Text.ToString()) - Convert.ToDouble(textBoxPagaCon.Text.ToString());

                                nuevaCompra.Proveedores_IdProveedor = Convert.ToInt32(comboBoxProveedor.SelectedValue.ToString());

                                nuevaCompra.TipoPago_IdTipoPago = Convert.ToInt32(comboBoxTipoPago.SelectedValue.ToString());

                                nuevaCompra.NombreEntrega = textBoxRealizaCompra.Text.ToString();

                                nuevaCompra.NombreRecibe = textBoxRecibe.Text.ToString();

                                conexionBd.ComprasSet.Add(nuevaCompra);
                                conexionBd.SaveChanges();


                                //Gauardar detalleCompra----Recorro con un ciclo los registros de grid y los almaceno a la tabla
                                for (int i = 0; i < dataGridDetalleComprasMaderas.Rows.Count; i++)
                                {
                                    DetalleComprasSet agregandoProductoCompra = new DetalleComprasSet();

                                    agregandoProductoCompra.Cantidad = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[4].Value);
                                    agregandoProductoCompra.Subtotal = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[5].Value);
                                    agregandoProductoCompra.Compras_IdCompra = idContador;
                                    agregandoProductoCompra.PrecioCompraProveedorSet_IdPrecioCpm = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[0].Value);
                                    conexionBd.DetalleComprasSet.Add(agregandoProductoCompra);
                                    conexionBd.SaveChanges();

                                    //ACTUALIZAR EL STOCK DE LA TABLA DESDE AQUI; SI SE AGREGA A LA COMPRA
                                    int idMadera = 0;
                                    idMadera = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[7].Value);

                                    MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();

                                    long actualizaStockBd = Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[2].Value) + Convert.ToInt64(this.dataGridDetalleComprasMaderas.Rows[i].Cells[4].Value);
                                    maderaEncontrado.Stock = Convert.ToInt64(actualizaStockBd);
                                    conexionBd.SaveChanges();

                                }
                                this.Close();
                            } 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar las maderas para comprar", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCantidad.Focus();
                }

            }//REALIZAR PROCESO PARA CANCELAR LA COMPRA
            else
            {
                if (MessageBox.Show("¿Esta seguro que desea cancelar la compra, si la compra  es por abono, tambien se borrara el historial de ABONOS?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    //****************1111111111 :) ELIMINO DE LA TABLA DETALLESCOMPRAS LOS REGISTROS
                    int idDetalleCompra = 0;
                    int idMadera = 0;

                    for (int i = 0; i < dataGridDetalleComprasMaderas.Rows.Count; i++)
                    {
                         idDetalleCompra = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[8].Value);

                        DetalleComprasSet detalleMadera = conexionBd.DetalleComprasSet.Where(x => x.IdDetalleCompra == idDetalleCompra).Select(x => x).FirstOrDefault();
                        conexionBd.DetalleComprasSet.Remove(detalleMadera);
                        conexionBd.SaveChanges();

                        //****************2222222222 :) ACTUALIZO EL REGISTRO DE LA TABLA MADERAS DE STOCK POR CADA REGISTRO QUE ELIMINO
                        idMadera = Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[7].Value);

                        MaderasSet maderaEncontrado = conexionBd.MaderasSet.Where(x => x.IdMadera == idMadera).Select(x => x).FirstOrDefault();
                        long actualizaStockBd = maderaEncontrado.Stock - Convert.ToInt32(this.dataGridDetalleComprasMaderas.Rows[i].Cells[4].Value); ;
                        maderaEncontrado.Stock = Convert.ToInt64(actualizaStockBd);
                        conexionBd.SaveChanges();
                    }


                    //SOLO ENTRA AQUI CUANDO LA COMPRA ES POR ABONO
                    if(Convert.ToInt32(comboBoxTipoPago.SelectedValue.ToString()) != 1){

                        //****************3333333333333 :) ELIMINO LOS ABONOS DE ESA COMPRA
                        var buscarAbonosDesaCompra = (from a in conexionBd.RegistroAbonoProveedorSet
                                                      where a.Compras_IdCompra == idCompra
                                                      select a);

                        for (int i = 0; i < buscarAbonosDesaCompra.Count(); i++)
                        {
                            //Elimina registro por registro
                            RegistroAbonoProveedorSet detalleMadera = conexionBd.RegistroAbonoProveedorSet.Where(x => x.Compras_IdCompra == idCompra).Select(x => x).FirstOrDefault();
                            conexionBd.RegistroAbonoProveedorSet.Remove(detalleMadera);
                            conexionBd.SaveChanges();
                            i--;   //Cada vez que se elimine un registro restamos a i por que el tamano de la lista va cambiando
                        }
                    }
                   

                    //****************444444444444  POR ULTIMO ELIMINO LA COMPRA
                    ComprasSet compraEncont = conexionBd.ComprasSet.Where(x => x.IdCompra == idCompra).Select(x => x).FirstOrDefault();
                    conexionBd.ComprasSet.Remove(compraEncont);
                    conexionBd.SaveChanges();

                    this.Close();
                }
            }
            
        }


        private void textBoxPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales.aceptasolonumerodecimal(sender, e, ('.'));
        }

        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEnteros.aceptasolonumeros(sender, e);
        }
    }
}
