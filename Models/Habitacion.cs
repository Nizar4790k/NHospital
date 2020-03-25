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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdHabitacion { get; set; }

        [StringLength(8)]
        public string Numero { get; set; }

        [StringLength(8)]
        public string Tipo { get; set; }

        public decimal? Precio { get; set; }
    }
}
