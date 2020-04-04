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

         const int MAX = 2147483647;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            Ingreso = new HashSet<Ingreso>();

        }

        [Key]
        public int IdHabitacion { get; set; }

        [Range(0, 2147483647, ErrorMessage ="Valor no valido")]
        
        [Required(ErrorMessage ="El numero de habitacion es obligatorio")]
        public int Numero { get; set; }

      
        public int IdTipo { get; set; }

        [Range(0, 2147483647, ErrorMessage = "Valor no valido")]
        [Required(ErrorMessage = "El precio de la habitacion es obligatorio")]
        public decimal Precio { get; set; }

        public virtual TipoHabitacion TipoHabitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingreso> Ingreso { get; set; }
    }
}
