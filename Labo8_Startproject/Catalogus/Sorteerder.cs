using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogus
{
    public class Sorteerder : IComparer<IBibItem>
    {
        public int Compare(IBibItem x, IBibItem y)
        {
            if (x is Afdeling && !(y is Afdeling))
                return -1;
            if (y is Afdeling && !(x is Afdeling))
                return 1;
            if (y is Afdeling && x is Afdeling)
            {
                string nx = ((Afdeling)x).Naam + " - " + x.Id;
                string ny = ((Afdeling)y).Naam + " - " + y.Id;
                return nx.CompareTo(ny);
            }
            if (x is Boek && !(y is Boek))
                return -1;
            if (y is Boek && !(x is Boek))
                return 1;
            if (x is Boek && y is Boek)
            {
                Boek bx = (Boek)x;
                Boek by = (Boek)y;
                string sx = bx.Auteur + " - " + bx.Titel + " - " + bx.Id;
                string sy = by.Auteur + " - " + by.Titel + " - " + by.Id; ;
                return sx.CompareTo(sy);
            }
            if (x is Tijdschrift && !(y is Tijdschrift))
                return -1;
            if (y is Tijdschrift && !(x is Tijdschrift))
                return 1;
            if (x is Tijdschrift && y is Tijdschrift)
            {
                Tijdschrift bx = (Tijdschrift)x;
                Tijdschrift by = (Tijdschrift)y;
                string sx = bx.Titel + " - " + bx.Id;
                string sy = by.Titel + " - " + by.Id;
                return sx.CompareTo(sy);
            }
            return 0;

        }
    }
}


