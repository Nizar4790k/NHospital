namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cita")]
    public partial class Cita
    {
        [Key]
        public int IdCita { get; set; }

        public DateTime Fecha { get; set; }

        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
