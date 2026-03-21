using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codering
{
    public class WisselCodering : ACodering
    {
        public WisselCodering(ICodering codering) : base(codering)
        {

        }

        public override string CodeerZin(string zin)
        {
            // lengte even?
            if (zin.Length % 2 != 0)
            {
                zin += '0'; //minder goede oplossing - beter StringBuilder gebruiken
            }
            // codering door wisselen
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zin.Length; i += 2)
            {
                // letters verwisselen
                result.Append(zin[i + 1]);
                result.Append(zin[i]);
            }
            return result.ToString();
        }


    }
}
