using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogus
{
    public abstract class ABibItem : IBibItem
    {
        public string Id { get; set; }
        public IBibItem Ouder { get; set; }

        public abstract string Inhoud { get; }

        public virtual string Toon(int insprong)
        {
            string toon = "";
            for (int i = 0; i < insprong; i++)
            {
                toon += "-";
            }
            toon += Inhoud;
            return toon;
        }

        public void VerplaatsNaar(IBibItem bibItem)
        {
            Ouder.Verwijder(this);
            Ouder = bibItem;
            bibItem.VoegToe(this);
        }

        public virtual void Verwijder(IBibItem bibItem)
        {
        }

        public virtual void VoegToe(IBibItem bibItem)
        {
        }

        public virtual IBibItem Zoek(string id)
        {
            if (id.Equals(Id)) return this;
            else return null;
        }

        public abstract bool HasTrefwoord(string trefwoord);

        public virtual IEnumerable<IBibItem> ZoekTrefwoord(string trefwoord)
        {
            if (HasTrefwoord(trefwoord))
            {
                yield return this;
            }
        }
    }
}
