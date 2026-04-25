using Codering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderingen
{
    public abstract class ACodering : ICodering
    {
        public string Codeer(string zin)
        {
            StringBuilder zinBuffer = new StringBuilder(zin.ToLower());

            if (BoolVervang())
            {
                zinBuffer = VerwijderSpecialeTekens(zinBuffer);
            }
            if (BoolOneven())
            {
                zinBuffer = MaakEven(zinBuffer);
            }
            zin = Codering(zinBuffer.ToString());

            return zin;
        }

        public abstract string Codering(string zin);
        public override abstract string ToString();


        private StringBuilder MaakEven(StringBuilder builder)
        {
            if (builder.Length % 2 == 1)
            {
                builder.Append(0);
            }
            return builder;
        }

        private StringBuilder VerwijderSpecialeTekens(StringBuilder builder)
        {
            // verwijder speciale tekens
            for (int i = 0; i < builder.Length; i++)
            {
                if (!char.IsLower(builder[i]) && !char.IsDigit(builder[i]))
                {
                    builder[i] = '0';
                }
            }
            return builder;
        }

        protected virtual bool BoolVervang()
        {
            return true;
        }

        protected virtual bool BoolOneven()
        {
            return true;
        }
    }
}
