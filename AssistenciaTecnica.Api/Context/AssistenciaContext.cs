using Api4;
using AssistenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaApi.Context
{
    public class AssistenciaContext: DbContext
    {
        public AssistenciaContext(DbContextOptions<AssistenciaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdemDeServico>()
                .Property(x => x.Valor)
                .HasPrecision(10, 2);
        }
    }
}
