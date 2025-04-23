namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroAbonoProveedorSet")]
    public partial class RegistroAbonoProveedorSet
    {
        [Key]
        public int IdAbono { get; set; }

        public DateTime FechaAbono { get; set; }

        public double Debia { get; set; }

        public double Abono { get; set; }

        public double Debe { get; set; }

        [Required]
        public string RecibeAbono { get; set; }

        public int Compras_IdCompra { get; set; }

        public virtual ComprasSet ComprasSet { get; set; }
    }
}
