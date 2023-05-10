using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_example")]
    internal class ExampleHit : BaseHit
    {
        public static string Code => "Example";
    }
}
