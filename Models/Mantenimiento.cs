namespace NHospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Mantenimiento : DbContext
    {
        public Mantenimiento()
            : base("name=Mantenimiento")
        {
        }

        public virtual DbSet<Habitacion> Habitaciones { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Exequatur)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Especialidad)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Cedula)
                .IsUnicode(false);
        }
    }
}
