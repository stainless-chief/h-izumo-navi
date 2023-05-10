using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305011044, "Fill database with sample data")]
    public class M202305011044_FillDbWithSamples : Migration
    {
        private readonly string _sourceName = ExampleHit.Code.ToLower();
        private const string _hit = "hit";

        public override void Up()
        {
            for (int i = 0; i < 100; i++)
            {
                //Izumo Enmusubi Airport
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.413789}', 
                        '{132.886314}'
                    );");
            }

            for (int i = 0; i < 90; i++)
            {
                //Izumo Airport Country Club
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.385646}', 
                        '{132.860302}'
                    );");
            }

            for (int i = 0; i < 80; i++)
            {
                //Izumo Airport Country Club
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.384559}', 
                        '{132.820309}'
                    );");
            }

            for (int i = 0; i < 70; i++)
            {
                //Mankusen Jinja
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.374605}', 
                        '{132.787088}'
                    );");
            }

            for (int i = 0; i < 60; i++)
            {
                //Tabushi Station
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.421902}', 
                        '{132.806963}'
                    );");
            }

            for (int i = 0; i < 50; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.440182}', 
                        '{132.774025}'
                    );");
            }

            for (int i = 0; i < 40; i++)
            {
                // Cape Uppurui-hana Lighthouse
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.469707}', 
                        '{132.728328}'
                    );");
            }

            for (int i = 0; i < 30; i++)
            {
                // Lakeside Hot Spring Hotel Kunibiki
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.324472}', 
                        '{132.677099}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                // 7-Eleven
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.367605}', 
                        '{132.733781}'
                    );");
            }

            for (int i = 0; i < 10; i++)
            {
                // Umibozu
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.363490}',
                        '{132.756296}'
                    );");
            }
        }

        public override void Down()
        {
            Execute.Sql(@$"DELE FROM {DataContext.SchemaData}.{_hit}_{_sourceName};");
        }
    }
}
