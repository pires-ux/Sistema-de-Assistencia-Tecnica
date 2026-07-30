using Api4;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaApi.Context
{
    public class AssistenciaContext: DbContext
    {
        public AssistenciaContext(DbContextOptions<AssistenciaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }

    }
}
