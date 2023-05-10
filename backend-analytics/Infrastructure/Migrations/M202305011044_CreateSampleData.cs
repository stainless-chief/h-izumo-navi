using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202305011044, "Fill database with sample data")]
    public class M202305011044_FillDbWithSamples : Migration
    {
        private const string _sourceName = "example";
        private const string _hit = "hit";

        public override void Up()
        {
            for (int i = 0; i < 100; i++)
            {
                //Izumo Enmusubi Airport
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.413789}', 
                        '{132.886314}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 90; i++)
            {
                //Izumo Airport Country Club
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.385646}', 
                        '{132.860302}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 80; i++)
            {
                //Izumo Airport Country Club
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.384559}', 
                        '{132.820309}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 70; i++)
            {
                //Mankusen Jinja
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.374605}', 
                        '{132.787088}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 60; i++)
            {
                //Tabushi Station
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.421902}', 
                        '{132.806963}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 50; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.440182}', 
                        '{132.774025}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 40; i++)
            {
                // Cape Uppurui-hana Lighthouse
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.469707}', 
                        '{132.728328}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 30; i++)
            {
                // Lakeside Hot Spring Hotel Kunibiki
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.324472}', 
                        '{132.677099}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                // 7-Eleven
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.367605}', 
                        '{132.733781}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 10; i++)
            {
                // Umibozu
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{035.363490}',
                        '{132.756296}', 
                        '{100}'
                    );");
            }
        }

        public override void Down()
        {
            Execute.Sql(@$"DELE FROM {DataContext.SchemaData}.{_hit}_{_sourceName};");
        }
    }
}
