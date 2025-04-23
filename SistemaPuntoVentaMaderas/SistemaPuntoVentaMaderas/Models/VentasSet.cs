namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VentasSet")]
    public partial class VentasSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VentasSet()
        {
            DetalleVentasSet = new HashSet<DetalleVentasSet>();
            RegistroAbonoClientesSet = new HashSet<RegistroAbonoClientesSet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVenta { get; set; }

        public DateTime FechaVenta { get; set; }

        public long TotalProducto { get; set; }

        public double PrecioTotal { get; set; }

        public DateTime FechaRegistro { get; set; }

        public double PagoCon { get; set; }

        public double Deuda { get; set; }

        public int ClientesSet_IdCliente { get; set; }

        public int TipoPagoSet_IdTipoPago { get; set; }

        [Required]
        public string NombreEntrega { get; set; }

        [Required]
        public string NombreRecibe { get; set; }

        public virtual ClientesSet ClientesSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentasSet> DetalleVentasSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroAbonoClientesSet> RegistroAbonoClientesSet { get; set; }

        public virtual TipoPagoSet TipoPagoSet { get; set; }
    }
}
