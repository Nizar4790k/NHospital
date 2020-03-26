namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Habitacion")]
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            Ingresoes = new HashSet<Ingreso>();
        }

        [Key]
        public int IdHabitacion { get; set; }

        [Required]
        [StringLength(8)]
        public string Numero { get; set; }

        public int IdTipo { get; set; }

        public decimal Precio { get; set; }

        public virtual TipoHabitacion TipoHabitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingreso> Ingresoes { get; set; }
    }
}
