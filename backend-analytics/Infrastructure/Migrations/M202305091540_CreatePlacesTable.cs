using Abstractions.Models;
using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202305091540, "Create places table")]
    public class M202305091540_CreatePlacesTable : Migration
    {
        private const string _placeTable = "place";

        public override void Up()
        {
            Execute.Sql(
                $@"CREATE TABLE {DataContext.SchemaData}.{_placeTable} 
                (
	                id uuid NOT NULL UNIQUE,
	                display_name VARCHAR(128) NOT NULl,
                    latitude_max float NOT NULL,
                    longitude_max float NOT NULL,
                    
                    latitude_min float NOT NULL,
                    longitude_min float NOT NULL,

					PRIMARY KEY(id)
                );");

            //Izumo Enmusubi Airport
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, latitude_max, longitude_max, latitude_min, longitude_min)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Enmusubi Airport', 
                        '{035.4107592}', 
                        '{132.8994229}', 
                        '{035.4158014}', 
                        '{132.8761651}'
                    );");

            //Izumo Hinomisaki Lighthouse
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, latitude_max, longitude_max, latitude_min, longitude_min)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Hinomisaki Lighthouse', 
                        '{035.4334860}', 
                        '{132.6302785}', 
                        '{035.4340018}', 
                        '{132.6288623}'
                    );");

            //Karakama Shrine
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, latitude_max, longitude_max, latitude_min, longitude_min)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'IKarakama Shrine', 
                        '{035.4185180}', 
                        '{132.7192875}', 
                        '{035.4233787}', 
                        '{132.7103409}'
                    );");

            //Lakeside Hot Spring Hotel Kunibiki
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, latitude_max, longitude_max, latitude_min, longitude_min)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Lakeside Hot Spring Hotel Kunibiki', 
                        '{035.3241729}', 
                        '{132.6777651}', 
                        '{035.3245668}', 
                        '{132.6764562}'
                    );");

            //Umibozu
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, latitude_max, longitude_max, latitude_min, longitude_min)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Umibozu', 
                        '{035.3633809}', 
                        '{132.7564191}', 
                        '{035.3635035}',  
                        '{132.7561897}'
                    );");
        }

        public override void Down()
        {
            Execute.Sql(@$"DROP TABLE IF EXISTS {DataContext.SchemaData}.{_placeTable} CASCADE;");
        }
    }
}
