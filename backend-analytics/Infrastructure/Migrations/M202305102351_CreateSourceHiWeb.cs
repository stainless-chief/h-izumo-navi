using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305102351, "Create hiweb source")]
    public class M202305102351_CreateSourceHiWeb : BaseSourceHitDataMigration
    {
        protected override string SourceCode => HiWebHit.Code;

        protected override string SourceDisplayName => "Hi Izumo Web website";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
