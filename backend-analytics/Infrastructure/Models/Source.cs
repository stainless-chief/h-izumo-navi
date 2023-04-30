using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("source")]
    internal class Source
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
