namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComprasSet")]
    public partial class ComprasSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComprasSet()
        {
            DetalleComprasSet = new HashSet<DetalleComprasSet>();
            RegistroAbonoProveedorSet = new HashSet<RegistroAbonoProveedorSet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCompra { get; set; }

        public DateTime FechaCompra { get; set; }

        public long TotalProducto { get; set; }

        public double PrecioTotal { get; set; }

        public DateTime FechaRegistro { get; set; }

        public double PagoCon { get; set; }

        public double Deuda { get; set; }

        public int Proveedores_IdProveedor { get; set; }

        public int TipoPago_IdTipoPago { get; set; }

        [Required]
        public string NombreEntrega { get; set; }

        [Required]
        public string NombreRecibe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleComprasSet> DetalleComprasSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroAbonoProveedorSet> RegistroAbonoProveedorSet { get; set; }

        public virtual ProveedoresSet ProveedoresSet { get; set; }

        public virtual TipoPagoSet TipoPagoSet { get; set; }
    }
}
