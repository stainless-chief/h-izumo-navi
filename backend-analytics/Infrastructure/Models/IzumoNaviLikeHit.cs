using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_izumo_navi_like")]
    internal class IzumoNaviLikeHit : BaseHit
    {
        public static string Code => "Izumo_Navi_Like";

        [Column("emotion")]
        public int Emotion { get; set; }
    }
}
