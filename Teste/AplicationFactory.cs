 using Api4;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using AssistenciaApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal class AplicationFactory: WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove o banco configurado pela API
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<Conexao>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Adiciona o banco exclusivo dos testes
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(
                        "Server=localhost;Database=GestaoProdutosClientesDb_Test;Trusted_Connection=True;TrustServerCertificate=True;"
                    );
                });

                // Cria o provedor de serviços
                var serviceProvider = services.BuildServiceProvider();

                // Cria um escopo para o AppDbContext
                using var scope = serviceProvider.CreateScope();

                // Obtém o AppDbContext
                var db = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                // Aplica as migrations no banco de teste
                db.Database.Migrate();
            });
        }
    }
}
