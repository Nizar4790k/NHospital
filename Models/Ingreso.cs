namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingreso")]
    public partial class Ingreso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingreso()
        {
            Altas = new HashSet<Alta>();
        }

        [Key]
        public int IdIngreso { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int IdHabitacion { get; set; }

        public int IdPaciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alta> Altas { get; set; }

        public virtual Habitacion Habitacion { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
