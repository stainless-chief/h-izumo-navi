using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_faketwitter")]
    internal class FakeTwitterHit : BaseHit
    {
        public static string Code => "FakeTwitter";
    }
}
