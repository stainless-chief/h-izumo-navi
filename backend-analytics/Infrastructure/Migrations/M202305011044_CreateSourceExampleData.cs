using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305011044, "Fill database with sample data")]
    public class M202305011044_CreateSourceExampleData : Migration
    {
        private readonly string _sourceName = ExampleHit.Code.ToLower();
        private const string _hit = "hit";

        public override void Up()
        {
            var logDay = new DateTime(2023, 03, 01);

            for (int i = 0; i < 100; i++)
            {
                //Izumo Enmusubi Airport
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{035.413789}', 
                        '{132.886314}'
                    );");
            }

            for (int i = 0; i < 100; i++)
            {
                //IZUMOSHI STATION
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.360808737972654}', 
                        '{132.75653804494115}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                //noise
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.36838754191659}', 
                        '{132.75360205499706}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                //noise
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.3730572801031}', 
                        '{132.74695801833607}'
                    );");
            }

            for (int i = 0; i < 10; i++)
            {
                //Izumo Taisha
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.40028749929116}', 
                        '{132.68531403727093}'
                    );");
            }

            for (int i = 0; i < 20; i++)
            {
                //Hinomisaki Shrine
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.429448225071845}', 
                        '{132.62947986675763}'
                    );");
            }

            for (int i = 0; i < 70; i++)
            {
                //Izumo Hinomisaki Lighthouse
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.43369640179697}', 
                        '{132.62931471315727}'
                    );");
            }

            for (int i = 0; i < 80; i++)
            {
                //Inasa Beach
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.400057690657206}', 
                        '{132.67250449211286}'
                    );");
            }
            for (int i = 0; i < 10; i++)
            {
                //Inasa Beach
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.400057690657206}', 
                        '{132.67250449211286}'
                    );");
            }
            for (int i = 0; i < 10; i++)
            {
                //Izumotaisha-Mae
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.3936017397614}', 
                        '{132.68714978947236}'
                    );");
            }
            for (int i = 0; i < 50; i++)
            {
                //Izumotaisha-Mae
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.39250136833724}', 
                        '{132.6735516656772}'
                    );");
            }
            for (int i = 0; i < 50; i++)
            {
                //AEON MALL IZUMO 
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.36768288196696}', 
                        '{132.73894408978106}'
                    );");
            }
            for (int i = 0; i < 10; i++)
            {
                //Mori no kumasan Izumo
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.36768288196696}', 
                        '{132.73894408978106}'
                    );");
            }

            for (int i = 0; i < 10; i++)
            {
                //PLANT Hikawaten
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.396917681674026}', 
                        '{132.86574245221865}'
                    );");
            }
            for (int i = 0; i < 10; i++)
            {
                //Confiseries Yoshioka
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.396652165215954}', 
                        '{132.85924362957863}'
                    );");
            }
            for (int i = 0; i < 20; i++)
            {
                //Confiseries Yoshioka
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.38435098043729}', 
                        '{132.82174405227715}'
                    );");
            }
            for (int i = 0; i < 80; i++)
            {
                //Confiseries Yoshioka
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.39530463763144}', 
                        '{132.71105336461127}'
                    );");
            }
            for (int i = 0; i < 80; i++)
            {
                //Confiseries Yoshioka
                Execute.Sql(
                    $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.39222891855925}', 
                        '{132.7192037715838}'
                    );");
            }
        }

        public override void Down()
        {
            Execute.Sql(@$"DELE FROM {DataContext.SchemaData}.{_hit}_{_sourceName};");
        }
    }
}
