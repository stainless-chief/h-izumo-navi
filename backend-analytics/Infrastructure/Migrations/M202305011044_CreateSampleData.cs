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
            // MARCH
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

                for (int i = 0; i < 40; i++)
                {
                    //Moonlit Rabbit Inn 
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.396670881023084}', 
                        '{132.69303411558639}'
                    );");
                }

                for (int i = 0; i < 60; i++)
                {
                    //Super Hotel Izumo Ekimae
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.360455738163466}', 
                        '{132.75645008659737}'
                    );");
                }

                for (int i = 0; i < 100; i++)
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
                        '{35.40147568484659}', 
                        '{132.6854161448377}'
                    );");
                }

                for (int i = 0; i < 20; i++)
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
                        '{35.43373288203316}', 
                        '{132.62934450559612}'
                    );");
                }

                for (int i = 0; i < 10; i++)
                {
                    //Hamayama Park
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.37837163163506}', 
                        '{132.7065951799203}'
                    );");
                }

                for (int i = 0; i < 10; i++)
                {
                    //Hamayama Park
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.43219564609066}', 
                        '{132.63338844646623}'
                    );");
                }

                for (int i = 0; i < 90; i++)
                {
                    //Ayumi
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.368506055005035}', 
                        '{132.7554250829865}'
                    );");
                }

                for (int i = 0; i < 10; i++)
                {
                    // Wild
                    Execute.Sql(
                        $@"INSERT INTO {DataContext.SchemaData}.{_hit}_{_sourceName}
                    (id, date, person, latitude, longitude)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        '{logDay}', 
                        'chief', 
                        '{35.46230744814101}', 
                        '{132.78584859498127}'
                    );");
                }
            }
        }

        public override void Down()
        {
            Execute.Sql(@$"DELE FROM {DataContext.SchemaData}.{_hit}_{_sourceName};");
        }
    }
}
