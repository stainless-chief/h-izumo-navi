using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_hiweb")]
    internal class HiWebHit : BaseHit
    {
        public static string Code => "HiWeb";
    }
}
