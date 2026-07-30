
using Api4.Controllers;
using AssistenciaApi.Context;
using AssistenciaApi.Interface;
using AssistenciaApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AssistenciaContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("Banco"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Banco"))));

            builder.Services.AddSingleton<Conexao>();

            builder.Services.AddScoped<ServiceCliente>();

            builder.Services.AddScoped<ServiceProblema>();

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

            var app = builder.Build();

        

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
