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
        public int IdIngreso { get; set; }

        [Key]
        public int IdAlta { get; set; }

        public DateTime FechaSalida { get; set; }

        public decimal MontoTotal { get; set; }

        public virtual Ingreso Ingreso { get; set; }
    }
}
