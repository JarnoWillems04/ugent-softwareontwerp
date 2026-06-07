using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Catalogus
{
    public abstract class ABibComposite : ABibItem
    {
        protected ICollection<IBibItem> elementen;
        public string Naam { get; set; }

        public ABibComposite()
        {
            Console.WriteLine("Making new list");
            elementen = new List<IBibItem>();
        }

        public override string Toon(int insprong)
        {
            String toon = "";

            for (int i = 0; i < insprong; i++)
            {
                toon += "-";
            }

            toon += Inhoud + ": \n";
            
            foreach (IBibItem item in elementen)
            {
                toon += item.Toon(insprong + 2) + "\n";
            }

            return toon;
        }

        public override void Verwijder(IBibItem bibItem)
        {
            if (elementen.Contains(bibItem))
            {
                elementen.Remove(bibItem);
                bibItem.Ouder = null;
            }            
        }

        public override void VoegToe(IBibItem bibItem)
        {
            elementen.Add(bibItem);
            bibItem.Ouder = this;
        }

        public override IBibItem Zoek(string id)
        {
            IBibItem item = base.Zoek(id);
            if (item != null) return item; // gevonden in zichzelf

            foreach (IBibItem bibItem in elementen)
            {
                IBibItem iitem = bibItem.Zoek(id);
                if (iitem != null) return iitem; // gevonden in kind
            }

            return null; // nergens gevonden
        }

        public override IEnumerable<IBibItem> ZoekTrefwoord(string trefwoord)
        {
            if (HasTrefwoord(trefwoord))
            {
                yield return this;
            }
            foreach (IBibItem item in elementen)
            {
                {
                    foreach (IBibItem bibitem in item.ZoekTrefwoord(trefwoord))
                        yield return bibitem;

                }
            }
        }
    }
}
