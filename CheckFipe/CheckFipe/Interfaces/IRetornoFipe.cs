using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Interfaces
{
    public interface IRetornoFipe
    {
        long Codigo { get; set; }
        string Nome { get; set; }
    }
}
