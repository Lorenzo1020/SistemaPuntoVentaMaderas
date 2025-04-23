namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaderasSet")]
    public partial class MaderasSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaderasSet()
        {
            PrecioCompraProveedorSet = new HashSet<PrecioCompraProveedorSet>();
            PrecioVentaClienteSet = new HashSet<PrecioVentaClienteSet>();
        }

        [Key]
        public int IdMadera { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public short Estatus { get; set; }

        public long Stock { get; set; }

        public long StockControl { get; set; }

        public DateTime FechaMovInventario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrecioCompraProveedorSet> PrecioCompraProveedorSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrecioVentaClienteSet> PrecioVentaClienteSet { get; set; }
    }
}
