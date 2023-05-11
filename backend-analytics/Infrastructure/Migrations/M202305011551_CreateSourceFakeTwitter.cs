using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202305011551, "Create fake twitter source")]
    public class M202305011551_CreateSourceFakeTwitter : BaseSourceHitDataMigration
    {
        protected override string SourceCode => FakeTwitterHit.Code;

        protected override string SourceDisplayName => "Fake twitter Data";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
