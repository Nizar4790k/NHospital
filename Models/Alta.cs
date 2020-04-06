namespace NHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alta")]
    public partial class Alta
    {


        
        [Range(0, 2147483647, ErrorMessage = "Valor no valido")]
        public int IdIngreso { get; set; }

        [Key]
        public int IdAlta { get; set; }
      
        [Required(ErrorMessage ="La fecha de alta es requerida")]
        public DateTime FechaSalida { get; set; }

        public decimal MontoTotal { get; set; }

       
        public virtual Ingreso Ingreso { get; set; }
    }
}
