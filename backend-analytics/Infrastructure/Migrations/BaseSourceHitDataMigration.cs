using FluentMigrator;

namespace Infrastructure.Migrations
{
    public abstract class BaseSourceHitDataMigration : Migration
    {
        protected abstract Guid SourceId { get; }
        protected abstract string SourceCode { get; }
        protected abstract string SourceDisplayName { get; }
        protected abstract string SourceDescription { get; }

        private const string TableSources = "source";
        private const string ViewSourcesToHits = "sources_to_hits";

        public override void Up()
        {
            Execute.Sql(
                $@"CREATE TABLE {DataContext.SchemaData}.hit_{SourceCode.ToLower()} 
                (
	                id uuid NOT NULL UNIQUE,
                    date DATE NOT NULL,
                    person VARCHAR(512) NOT NULL,
                    latitude float NOT NULL,
                    longitude float NOT NULL,

					PRIMARY KEY(id)
                );");

            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{TableSources} 
                    (id, code, display_name, description)
                VALUES
                (
                    '{SourceId}',
                    '{SourceCode}',
                    '{SourceDisplayName}',
                    '{SourceDescription}'
                );");
        }

        public override void Down()
        {
            Execute.Sql(@$"DROP TABLE IF EXISTS {DataContext.SchemaData}.{ViewSourcesToHits.ToLower()} CASCADE;");
            Execute.Sql(@$"DELETE FROM {DataContext.SchemaData}.{TableSources} WHERE ID = '{SourceId}'");
        }
    }
}
