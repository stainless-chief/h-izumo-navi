using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(197001010000, "Initialize schema")]
    public sealed class M197001010000_InitializeSchema : Migration
    {
        public override void Up()
        {
            Create.Schema(DataContext.SchemaData);
        }

        public override void Down()
        {
            Delete.Schema(DataContext.SchemaData);
        }
    }
}
