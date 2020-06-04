using CheckFipe.Infrastructure.Data.Contexts;

namespace CheckFipe.Teste.ContextTest
{
    public class CheckFipeContextTest : CheckFipeContext
    {

        public override void Dispose()
        {
            this.Database.EnsureDeleted();
            base.Dispose();
        }
    }
}
