namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientesSet")]
    public partial class ClientesSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientesSet()
        {
            PrecioVentaClienteSet = new HashSet<PrecioVentaClienteSet>();
            VentasSet = new HashSet<VentasSet>();
        }

        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string App { get; set; }

        [Required]
        public string Apm { get; set; }

        [Required]
        public string NumCel { get; set; }

        public string Correo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public short Estatus { get; set; }

        [Required]
        public string Calle { get; set; }

        public string NumInt { get; set; }

        public string NumExt { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Ciudad { get; set; }

        public string NombreEmpresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrecioVentaClienteSet> PrecioVentaClienteSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentasSet> VentasSet { get; set; }
    }
}
