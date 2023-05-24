using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("hit_fake_twitter")]
    internal class FakeTwitterHit : BaseHit
    {
        public static string Code => "Fake_Twitter";
    }
}
