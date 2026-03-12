
using System;
using System.Collections.Generic;


namespace Druk
{
    public class DrukPascal : IDruk
    {
        
        private double druk=101325;
        public string Eenheid { get; } = "Pa";
        public string Naam { get; } = "Pascal";

        public double Max { get; } = 1700000;
        public double Druk
        {
            get { return druk; }
            set
            {
                druk = Math.Max(0, Math.Min(value,Max));
            }
        }
    }
}
