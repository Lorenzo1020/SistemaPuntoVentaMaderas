namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrecioCompraProveedorSet")]
    public partial class PrecioCompraProveedorSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrecioCompraProveedorSet()
        {
            DetalleComprasSet = new HashSet<DetalleComprasSet>();
        }

        [Key]
        public int IdPrecioCpm { get; set; }

        public double PrecioMadera { get; set; }

        public short Estatus { get; set; }

        public int Proveedores_IdProveedor { get; set; }

        public int Maderas_IdMadera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleComprasSet> DetalleComprasSet { get; set; }

        public virtual MaderasSet MaderasSet { get; set; }

        public virtual ProveedoresSet ProveedoresSet { get; set; }
    }
}
