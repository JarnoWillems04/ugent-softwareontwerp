//Subject
using System;
using System.Collections.Generic;
using System.Text;

namespace Druk
{
    public interface IDruk
    {
        string Eenheid { get; }
        string Naam { get; }
        double Max {  get; }
        double Druk { get; set; }
        void Register(IObserver observer);
    }
}
