namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleComprasSet")]
    public partial class DetalleComprasSet
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        public long Cantidad { get; set; }

        public double Subtotal { get; set; }

        public int Compras_IdCompra { get; set; }

        public int PrecioCompraProveedorSet_IdPrecioCpm { get; set; }

        public virtual ComprasSet ComprasSet { get; set; }

        public virtual PrecioCompraProveedorSet PrecioCompraProveedorSet { get; set; }
    }
}
