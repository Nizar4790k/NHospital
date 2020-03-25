namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paciente")]
    public partial class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        public string Nombre { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }

        public bool? Asegurado { get; set; }
    }
}
