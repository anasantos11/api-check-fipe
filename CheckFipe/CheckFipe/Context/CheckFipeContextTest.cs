namespace CheckFipe.Context
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
