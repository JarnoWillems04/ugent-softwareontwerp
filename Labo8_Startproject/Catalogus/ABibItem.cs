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
            throw new NotImplementedException();
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
            if (this.Id == id) return this;
            return null;
        }
    }
}
