namespace SistemaPuntoVentaMaderas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuariosSet")]
    public partial class UsuariosSet
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string App { get; set; }

        [Required]
        public string Apm { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contrasena { get; set; }

        public short Estatus { get; set; }
    }
}
