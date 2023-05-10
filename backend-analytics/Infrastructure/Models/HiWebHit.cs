using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_hiizumo")]
    internal class HiWebHit : BaseHit
    {
        public static string Code => "HiIzumo";
    }
}
