using Abstractions.IRepositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace IzumoAnalytics
{
    public class Program
    {
        const string KeyDatabase = "PostgreSQL";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddApiVersioning();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString(KeyDatabase));
            });

            builder.Services.AddTransient<IHeatZoneRepository, HeatZoneRepository>();
            builder.Services.AddTransient<ISourceRepository, SourceRepository>();

            var app = builder.Build();
            app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DataContext>();
                context.Migrator.MigrateUp();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}