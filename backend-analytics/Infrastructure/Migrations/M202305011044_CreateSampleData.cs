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
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.413704}', 
                        '{132.886872}', 
                        '{100}'
                    );");
            }
            for (int i = 0; i < 100; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.382394}', 
                        '{132.811446}', 
                        '{100}'
                    );");
            }
            for (int i = 0; i < 100; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.385341}', 
                        '{132.858102}', 
                        '{100}'
                    );");
            }
            for (int i = 0; i < 90; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.383452}', 
                        '{132.865145}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 90; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.386690}', 
                        '{132.822675}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 80; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.400670}', 
                        '{132.685544}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 70; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.392681}', 
                        '{132.673238}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 60; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.389194}', 
                        '{132.725849}', 
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
                        '{35.384187}', 
                        '{132.824611}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 40; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.364862}', 
                        '{132.828777}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 30; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.376760}', 
                        '{132.850124}', 
                        '{100}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude, reliability)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{DateTime.Now}', 
                        'chief', 
                        '{35.420608}', 
                        '{132.877201}', 
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
