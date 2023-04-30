using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public const string SchemaData = "analytics";
        public const string SchemaHistory = "history";

        internal DbSet<Source> Sources => Set<Source>();

        internal DbSet<ExampleHit> ExampleHits => Set<ExampleHit>();

        public Migrator Migrator { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            Migrator = new Migrator(Database.GetConnectionString());

            //HACK: after postgreSQL update timestamps has been broken down
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaData);
        }
    }
}
