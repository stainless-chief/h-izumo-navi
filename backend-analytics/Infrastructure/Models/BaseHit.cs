using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    internal abstract class BaseHit
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }

        [Column("person")]
        public string Person { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        [Column("reliability")]
        public int Reliability { get; set; }
    }
}
