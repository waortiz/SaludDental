using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Modelo
{
    public class Contexto : DbContext
    {
        public Contexto() : base()
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConfigurationManager.ConnectionStrings["SaludDental"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TipoDocumento>()
                .HasMany(e => e.Pacientes)
                .WithOne(e => e.TipoDocumento)
                .HasForeignKey(e => e.IdTipoDocumento);

            builder.Entity<Sexo>()
                .HasMany(e => e.Pacientes)
                .WithOne(e => e.Sexo)
                .HasForeignKey(e => e.IdSexo);

            builder.Entity<Ciudad>()
                .HasMany(e => e.Pacientes)
                .WithOne(e => e.Ciudad)
                .HasForeignKey(e => e.IdCiudad);

            builder.Entity<Departamento>()
                .HasMany(e => e.Ciudades)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.IdDepartamento);
        }
    }
}