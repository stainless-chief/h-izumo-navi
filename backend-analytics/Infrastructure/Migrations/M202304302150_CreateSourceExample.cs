using FluentMigrator;
using Infrastructure.Models;

namespace Infrastructure.Migrations
{
    [Migration(202304302150, "Create example source")]
    public class M202304302150_CreateSourceExample : BaseSourceHitDataMigration
    {
        protected override string SourceCode => ExampleHit.Code;

        protected override string SourceDisplayName => "Example Data";

        protected override string SourceDescription => "Random data for demonstration purposes";

        protected override Guid SourceId => Guid.NewGuid();
    }
}
