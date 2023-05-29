using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("place")]
    internal class Place
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [Column("region")]
        public double[]? Region { get; set; }

        [Column("characteristics")]
        public string[]? Characteristics { get; set; }
    }
}
