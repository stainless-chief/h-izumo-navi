using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202305011551, "Create twitter source")]
    public class M202305011551_CreateSourceTwitter : BaseSourceHitDataMigration
    {
        protected override string SourceCode => "Twitter";

        protected override string SourceDisplayName => "Twitter Data";

        protected override string SourceDescription => "";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
