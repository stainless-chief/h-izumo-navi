using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public const string SchemaData = "analytics";
        public const string SchemaHistory = "history";
        public Migrator Migrator { get; set; }

        internal DbSet<Source> Sources => Set<Source>();
        internal DbSet<Place> Places => Set<Place>();


        internal DbSet<ExampleHit> ExampleHits => Set<ExampleHit>();
        internal DbSet<FakeTwitterHit> FakeTwitterHit => Set<FakeTwitterHit>();

        public DataContext(DbContextOptions options) : base(options)
        {
            var connectionString = Database.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is empty");
            }

            Migrator = new Migrator(connectionString);

            //HACK: after postgreSQL update timestamps has been broken down
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaData);
        }
    }
}
