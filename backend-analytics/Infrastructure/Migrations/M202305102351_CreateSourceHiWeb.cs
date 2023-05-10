using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202305102351, "Create hi izumo source")]
    public class M202305102351_CreateSourceHiWeb : BaseSourceHitDataMigration
    {
        protected override string SourceCode => "HiIzumo";

        protected override string SourceDisplayName => "Hi Izumo website";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
