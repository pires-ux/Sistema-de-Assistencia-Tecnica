
using Api4.Controllers;

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

            builder.Services.AddSingleton<Conexao>();

            builder.Services.AddScoped<Sql>();

            builder.Services.AddScoped<Service>();

            builder.Services.AddScoped<ServiceProblema>();

            builder.Services.AddScoped<SqlProblema>();


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
