using System;
using System.Collections.Generic;
using System.Text;

namespace Codering
{
    public abstract class ACodering : ICodering
    {
        private ICodering codering;
        public ACodering(ICodering codering)
        {
            this.codering = codering;
        }

        public ICodering InterneCodering => codering;

        public string Codeer(string zin)
        {
            return CodeerZin(zin);
        }

        public abstract string CodeerZin(string zin);
    }
}
