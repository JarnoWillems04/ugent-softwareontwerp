using System;
using System.Collections.Generic;
using System.Text;

namespace Codering
{
    public class CodeerHelper
    {
        private Dictionary<String, ICodering> coderingen = new();

        public CodeerHelper() 
        {
            coderingen["Blok"] = new BlokCodering();
            coderingen["Wissel"] = new WisselCodering();
            coderingen["Cijfer"] = new CijferCodering();
            //coderingen["Test"] = new CijferCodering();
        }

        // Staat gewoon in opdracht om te gebruiken (mag als comment staan)
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
