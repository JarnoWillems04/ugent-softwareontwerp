using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codering
{
    public class CijferCodering: ACodering
    {

        public CijferCodering(ICodering codering) : base(codering)
        {
        }

        public override string CodeerZin(string zin)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zin.Length; i++)
            {
                int code = zin[i];
                result.Append(code);
            }
            return result.ToString();
        }

    }
}
