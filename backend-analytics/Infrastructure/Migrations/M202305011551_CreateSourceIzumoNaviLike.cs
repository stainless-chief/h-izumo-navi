using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305241849, "Create Izumo-navy like source")]
    public class M202305241849_CreateSourceIzumoNaviLike : BaseSourceHitDataMigration
    {
        protected override string SourceCode => IzumoNaviLikeHit.Code;

        protected override string SourceDisplayName => "Izumo navi web-site";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
