namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleVentasSet")]
    public partial class DetalleVentasSet
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public long Cantidad { get; set; }

        public double SubTotal { get; set; }

        public int Ventas_IdVenta { get; set; }

        public int PrecioVentaClienteSet_IdPrecioVcm { get; set; }

        public virtual PrecioVentaClienteSet PrecioVentaClienteSet { get; set; }

        public virtual VentasSet VentasSet { get; set; }
    }
}
