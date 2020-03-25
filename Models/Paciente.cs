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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Citas = new HashSet<Cita>();
            Ingresoes = new HashSet<Ingreso>();
        }

        [Key]
        public int IdPaciente { get; set; }

        [Required]
        public string Nombre { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }

        public bool Asegurado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Citas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingreso> Ingresoes { get; set; }
    }
}
