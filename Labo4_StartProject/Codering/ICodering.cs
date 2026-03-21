using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codering
{
    public interface ICodering
    {
        string Codeer(string codeer);

        ICodering InterneCodering {  get; }

    }
}
