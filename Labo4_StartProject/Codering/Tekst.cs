using System;
using System.Collections.Generic;
using System.Text;

namespace Codering
{
    public class Tekst : ICodering
    {
        public ICodering InterneCodering // = public ICodering InterneCodering => this;
        {
            get
            {
                return this;
            }
        }

        public string Codeer(string zin)
        {
            return zin;
        }
    }
}
