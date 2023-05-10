using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("place")]
    internal class Place
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [Column("latitude_max")]
        public double LatitudeMax { get; set; }

        [Column("longitude_max")]
        public double LongitudeMax { get; set; }

        [Column("latitude_min")]
        public double LatitudeMin { get; set; }

        [Column("longitude_min")]
        public double LongitudeMin { get; set; }
    }
}
