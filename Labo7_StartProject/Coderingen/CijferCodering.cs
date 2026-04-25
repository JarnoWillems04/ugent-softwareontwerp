using System.Text;


namespace Codering
{
    public class CijferCodering: ICodering
    {
        public override string ToString()
        {
            return "Cijfer";
        }

        public string Codeer(string zin)
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
