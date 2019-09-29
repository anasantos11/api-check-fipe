using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
