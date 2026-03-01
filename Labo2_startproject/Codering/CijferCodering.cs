using System;
using System.Collections.Generic;
using System.Text;

namespace Codering
{
    internal class CijferCodering : ICodering
    {
        public string Codeer(string zin) {
            StringBuilder result = new();
            for (int i = 0; i < zin.Length; i++)
            {
                int code = zin[i];
                result.Append(code);
            }
            return result.ToString();
        }
    }
}
