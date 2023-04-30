using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202304302138, "Create source table")]
    public class M202304302138_CreateSourceTable : Migration
    {
        private const string _sourcesTable = "source";

        public override void Up()
        {
            Execute.Sql(
                $@"CREATE TABLE {DataContext.SchemaData}.{_sourcesTable} 
                (
	                id uuid NOT NULL UNIQUE,
	                code varchar(128) NOT NULL UNIQUE,
	                display_name VARCHAR(128) NOT NULl,
                    description VARCHAR(128) NOT NULl,

					PRIMARY KEY(id)
                );");
        }

        public override void Down()
        {
            Execute.Sql(@$"DROP TABLE IF EXISTS {DataContext.SchemaData}.{_sourcesTable} CASCADE;");
        }
    }
}
