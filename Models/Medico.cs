namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medico")]
    public partial class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        public string Nombre { get; set; }

        public string Exequatur { get; set; }

        public string Especialidad { get; set; }
    }
}
