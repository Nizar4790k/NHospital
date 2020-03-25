namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoHabitacion")]
    public partial class TipoHabitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoHabitacion()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        [Key]
        public int IdTipo { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
