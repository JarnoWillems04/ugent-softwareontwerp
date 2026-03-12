using System;
using System.Collections.Generic;
using System.Text;

namespace Druk
{
    public class WillekeurigeDruk : DrukPascal
    {
        string eenheid, naam;
        double factor;
        public WillekeurigeDruk(string eenheid, string naam, double factor)
        {
            this.eenheid = eenheid;
            this.naam = naam;
            this.factor = factor;

            base.Druk /= factor;
        }

        public override string Eenheid { get { return eenheid; } }
        public override string Naam { get { return naam; } }
        public override double Max { get { return base.Max / factor; } }
    }
}
