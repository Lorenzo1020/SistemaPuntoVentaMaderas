namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrecioVentaClienteSet")]
    public partial class PrecioVentaClienteSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrecioVentaClienteSet()
        {
            DetalleVentasSet = new HashSet<DetalleVentasSet>();
        }

        [Key]
        public int IdPrecioVcm { get; set; }

        public double PrecioMadera { get; set; }

        public short Estatus { get; set; }

        public int Clientes_IdCliente { get; set; }

        public int Maderas_IdMadera { get; set; }

        public virtual ClientesSet ClientesSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentasSet> DetalleVentasSet { get; set; }

        public virtual MaderasSet MaderasSet { get; set; }
    }
}
