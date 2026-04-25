namespace Codering
{
    public class CodeerHelper
    {
        Dictionary<string, ICodering> coderingen = new();
        
        public CodeerHelper() {
            coderingen["NoCodering"] = new NoCodering();
            coderingen["Cijfer"] = new CijferCodering();
            coderingen["Blok"] = new BlokCodering();
            coderingen["Wissel"] = new WisselCodering();
        }
        public IEnumerable<string> NamenCoderingen
        {
            get { return coderingen.Keys; }
        }

        public IEnumerable<ICodering> Coderingen
        {
            get { return coderingen.Values; }
        }

        public ICodering this[string type]
        {
            get
            {
                return coderingen[type];
            }
        }
    }
}
