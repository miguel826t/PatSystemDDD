using Microsoft.EntityFrameworkCore;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using PatSystem.Domain.Entities.SegDesemprego;

namespace PatSystem.Infra.Data
{
   public class PatSystemContext : DbContext
    {
        public PatSystemContext(DbContextOptions<PatSystemContext> options)
                  : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Curriculo> Curriculo { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<Idioma> Idioma { get; set; }
        public DbSet<CursoSuperior> CursoSuperior { get; set; }
        public DbSet<CursoTecnico> CursoTecnico { get; set; }

        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<Cbo> Cbo { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(sc => sc.ClienteId);
            modelBuilder.Entity<Curriculo>().HasKey(sc => sc.CurriculoID);
            modelBuilder.Entity<Experiencia>().HasKey(sc => new { sc.CurriculoID, sc.ExperienciaId });
            modelBuilder.Entity<Idioma>().HasKey(sc => new { sc.CurriculoID, sc.IdiomaId });
            modelBuilder.Entity<CursoSuperior>().HasKey(sc => new { sc.CurriculoID, sc.CursoSuperiorId });
            modelBuilder.Entity<CursoTecnico>().HasKey(sc => new { sc.CurriculoID, sc.CursoTecnicoId });

            modelBuilder.Entity<Seguro>().HasKey(Pk => Pk.SeguroId);
            modelBuilder.Entity<Cbo>().HasKey(Pk => Pk.CodCboId);
            modelBuilder.Entity<Empresa>().HasKey(Pk => Pk.EmpresaId);
        }
    }
}
