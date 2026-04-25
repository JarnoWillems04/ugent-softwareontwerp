using Coderingen;
using System.Text;


namespace Codering
{
    public class CijferCodering: ACodering
    {
        public override string ToString()
        {
            return "Cijfer";
        }

        public override string Codering(string zin)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zin.Length; i++)
            {
                int code = zin[i];
                result.Append(code);
            }
            return result.ToString();
        }

        protected override bool BoolOneven()
        {
            return false;
        }
    }
}
