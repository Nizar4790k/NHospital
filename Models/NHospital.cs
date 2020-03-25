namespace NHospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NHospital : DbContext
    {
        public NHospital()
    : base("name=NHospital")
        {
        }

        public virtual DbSet<Alta> Altas { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Habitacion> Habitacions { get; set; }
        public virtual DbSet<Ingreso> Ingresoes { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alta>()
                .Property(e => e.MontoTotal)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Habitacion>()
                .Property(e => e.Precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Habitacion>()
                .HasMany(e => e.Ingresoes)
                .WithRequired(e => e.Habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingreso>()
                .HasMany(e => e.Altas)
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
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Ingresoes)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoHabitacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoHabitacion>()
                .HasMany(e => e.Habitacions)
                .WithRequired(e => e.TipoHabitacion)
                .WillCascadeOnDelete(false);
        }
    }
}
