using FluentMigrator.Runner;
using Infrastructure.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public sealed class Migrator
    {
        private readonly string _connectionString;

        public Migrator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void MigrateUp()
        {
            using (var scope = CreateServices(_connectionString).CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.ListMigrations();
                runner.MigrateUp();
            }
        }

        public void MigrateDown(long version)
        {
            using (var scope = CreateServices(_connectionString).CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.ListMigrations();
                runner.MigrateDown(version);
            }
        }


        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(runner => runner
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .WithVersionTable(new VersionTable())
                    .ScanIn(typeof(Migrator).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}
