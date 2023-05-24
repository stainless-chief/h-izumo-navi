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
                    region float[] NOT NULL,

					PRIMARY KEY(id)
                );");

            //IZUMOSHI STATION
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumoshi Station',
                        '{{{string.Join(",", 
                                new[]
                                {
                                    35.36049900577044, 132.7557606254807,
                                    35.36075931051505, 132.75569864752674,
                                    35.360974124478055, 132.75743093133897,
                                    35.360726456564436, 132.7574867114975,
                                    35.36049900577044, 132.7557606254807,
                                })
                        }}}'
                    );");

            //Izumo Enmusubi Airport
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Enmusubi Airport',
                        '{{{string.Join(",",
                                new[]
                                {
                                    35.40709976358817, 132.87830799349535,
                                    35.40873789957489, 132.87740244985676,
                                    35.41259314062788, 132.88493639002215,
                                    35.414710720253616, 132.88378159450605,
                                    35.41665178599745, 132.88863534440918,
                                    35.4147842463508, 132.89013296984405,
                                    35.41956329699273, 132.89985851333026,
                                    35.41794580390438, 132.9012839640453,
                                    35.40709976358817, 132.87830799349535,
                                })}}}'
                    );");

            //Shōbara Station
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Shōbara Station',
                        '{{{string.Join(",",
                                new[]
                                {
                                 35.39326596137186, 132.86731366801982,
                                 35.39343651019444, 132.86724393058543,
                                 35.393904424342615, 132.86914025235893,
                                 35.393703265321896, 132.8692582695556,
                                 35.39326596137186, 132.86731366801982,
                                })}}}'
                    );");

            //Izumotaisha-Mae Station
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumotaisha-Mae Station',
                        '{{{string.Join(",",
                                new[]
                                {
                                 35.39337200398479, 132.68698559805023,
                                 35.393693173861266, 132.6869724653805,
                                 35.39337735682656, 132.68808874230535,
                                 35.39317394859004, 132.68794099977117,
                                 35.39337200398479, 132.68698559805023,
                                })}}}'
                    );");

            // Izumo Taisha
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Taisha',
                        '{{{string.Join(",",
                                new[]
                                {
                                 35.39659862762839, 132.68604668273883,
                                 35.39928364050923, 132.68441405712997,
                                 35.40328764584245, 132.68458591245727,
                                 35.40285573647418, 132.68637607211613,
                                 35.39935368314022, 132.6868343529888,
                                 35.396715369178075, 132.68704917214785,
                                 35.39659862762839, 132.68604668273883,
                                })}}}'
                    );");

            // Hinomisaki Shrine
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Hinomisaki Shrine',
                        '{{{string.Join(",",
                                new[]
                                {
                                 35.42929947567713, 132.62930144865834,
                                 35.42960455316726, 132.62896312966652,
                                 35.43001254655866, 132.62926987221908,
                                 35.42999416852244, 132.62970743144854,
                                 35.429740551194044, 132.6299825975619,
                                 35.42943179858585, 132.62993297744308,
                                 35.42934358333753, 132.62984275904526,
                                 35.42929947567713, 132.62930144865834,
                                })}}}'
                    );");

            // Izumo Hinomisaki Lighthouse
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Hinomisaki Lighthouse',
                        '{{{string.Join(",",
                                new[]
                                {
                                 35.43362725297328, 132.62907235197505,
                                 35.433935989496256, 132.62908137381484,
                                 35.433932314068436, 132.62972643535926,
                                 35.4335647704377, 132.62980312099742,
                                 35.43362725297328, 132.62907235197505,
                                })}}}'
                    );");

            // Owashi Beach
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Owashi Beach',
                        '{{{string.Join(",",
                                new[]
                                {
                                    35.43191656032791, 132.6334049782439,
                                    35.43241801708531, 132.63293695392156,
                                    35.43263721576489, 132.63337181116592,
                                    35.43217779866903, 132.63385089118094,
                                    35.43191656032791, 132.6334049782439,
                                })}}}'
                    );");

            // Izumo Glamping Reuna
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Izumo Glamping Reuna',
                        '{{{string.Join(",",
                                new[]
                                {
                                    35.424647226881724, 132.62493475924896,
                                    35.42557755424751, 132.62629981470772,
                                    35.425098908901354, 132.62722639780705,
                                    35.42428992438539, 132.62621708407386,
                                    35.424647226881724, 132.62493475924896,
                                })}}}'
                    );");

            // Super Hotel Izumo Ekimae
            Execute.Sql(
                $@"INSERT INTO {DataContext.SchemaData}.{_placeTable}
                    (id, display_name, region)
                    VALUES
                    (
                        '{Guid.NewGuid()}', 
                        'Super Hotel Izumo Ekimae',
                        '{{{string.Join(",",
                                new[]
                                {
                                    35.36035150064564, 132.756214677543,
                                    35.36048055819498, 132.75619456097456,
                                    35.36053852465425, 132.75653788374265,
                                    35.360420404278166, 132.75657811687955,
                                    35.36035150064564, 132.756214677543,
                                })}}}'
                    );");
        }

        public override void Down()
        {
            Execute.Sql(@$"DROP TABLE IF EXISTS {DataContext.SchemaData}.{_placeTable} CASCADE;");
        }
    }
}
