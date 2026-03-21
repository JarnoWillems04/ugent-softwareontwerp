

namespace Codering
{
    public class CodeerHelper
    {
        List<string> coderingen = new();
        public CodeerHelper()
        {
            coderingen.Add("Blok");
            coderingen.Add("Wissel");
            coderingen.Add("Cijfer");
        }
        public IEnumerable<string> NamenCoderingen
        {
            get { return coderingen; }
        }

        public ICodering AddCodering(string type, ICodering codering)
        {
            if (type == "Blok")
            {
                return new BlokCodering(codering);
            }
            else if (type == "Wissel") {
                return new WisselCodering(codering);
            }
            else if (type == "Cijfer"){
                return new CijferCodering(codering);
            }
            return codering;
        }

    }
}
