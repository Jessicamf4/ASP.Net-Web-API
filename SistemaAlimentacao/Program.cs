using Microsoft.EntityFrameworkCore;
using SistemaAlimentacao.Data;
using SistemaAlimentacao.Repositorios;
using SistemaAlimentacao.Repositorios.Interfaces;

namespace SistemaAlimentacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaRefeicaoDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IRefeicaoRepositorio, RefeicaoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://localhost:7273", "http://127.0.0.1:8080", "http://192.168.0.60:8080", "http://192.168.0.60:8080/page.html")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // ...
        }

        // No arquivo Startup.cs, no método Configure:
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...
            app.UseCors("AllowSpecificOrigin");

            // ...
        }




    }
}