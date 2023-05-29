using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305241849, "Create Izumo-navy like source")]
    public class M202305241849_CreateSourceIzumoNaviLike : BaseSourceHitDataMigration
    {
        protected override string SourceCode => IzumoNaviLikeHit.Code;

        protected override string SourceDisplayName => "Izumo navi web-site";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();

        public override void Up()
        {
            Execute.Sql(
                $@"CREATE TABLE {DataContext.SchemaData}.hit_{SourceCode.ToLower()} 
                (
	                id uuid NOT NULL UNIQUE,
                    date timestamp NOT NULL,
                    person VARCHAR(512) NOT NULL,
                    latitude float NOT NULL,
                    longitude float NOT NULL,
                    emotion integer,

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

            for (var i = 0; i < 10; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.hit_{SourceCode.ToLower()} 
                    (id, date, person, latitude, longitude, emotion)
                VALUES
                (
                    '{Guid.NewGuid()}',
                    '{DateTime.Now}',
                    '{"Chief"}',
                    '{35.40087906544714}',
                    '{132.6856393173969}',
                    '{100}'
                );");
            }

            for (var i = 0; i < 10; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.hit_{SourceCode.ToLower()} 
                    (id, date, person, latitude, longitude, emotion)
                VALUES
                (
                    '{Guid.NewGuid()}',
                    '{DateTime.Now}',
                    '{"Chief"}',
                    '{35.36076802285758}',
                    '{132.75616887550515}',
                    '{0}'
                );");
            }

            for (var i = 0; i < 10; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.hit_{SourceCode.ToLower()} 
                    (id, date, person, latitude, longitude, emotion)
                VALUES
                (
                    '{Guid.NewGuid()}',
                    '{DateTime.Now}',
                    '{"Chief"}',
                    '{35.43372141679074}',
                    '{132.6292551547577}',
                    '{0}'
                );");
            }
        }
    }
}
