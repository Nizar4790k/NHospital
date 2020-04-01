namespace NHospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NHospital : DbContext
    {
        public NHospital()
            : base("name=NHospital1")
        {
        }

        public virtual DbSet<Alta> Alta { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Ingreso> Ingreso { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alta>()
                .Property(e => e.MontoTotal)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Habitacion>()
                .HasMany(e => e.Ingreso)
                .WithRequired(e => e.Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingreso>()
                .HasMany(e => e.Alta)
                .WithRequired(e => e.Ingreso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Exequatur)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Especialidad)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Ingreso)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoHabitacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoHabitacion>()
                .HasMany(e => e.Habitacion)
                .WithRequired(e => e.TipoHabitacion)
                .WillCascadeOnDelete(false);
        }
    }
}
