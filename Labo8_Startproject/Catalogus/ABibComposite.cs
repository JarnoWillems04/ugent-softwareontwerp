using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Catalogus
{
    public abstract class ABibComposite : ABibItem
    {
        public ICollection<IBibItem> elementen;

        public ABibComposite()
        {
            Console.WriteLine("Making new list");
            elementen = new List<IBibItem>();
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
            if (item == null)
            {
                foreach (IBibItem bibItem in elementen)
                {
                    item = bibItem.Zoek(id);
                    if (item != null) return item;
                }
            }
            return item;
        }
    }
}
