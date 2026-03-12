
using System;
using System.Collections.Generic;


namespace Druk
{
    public class DrukPascal : IDruk
    {
        private double druk=101325;
        public virtual string Eenheid { get; } = "Pa";
        public virtual string Naam { get; } = "Pascal";

        public virtual double Max { get; } = 1700000;

        private List<IObserver> observers = new List<IObserver>();
        public double Druk
        {
            get { return druk; }
            set
            {
                druk = Math.Max(0, Math.Min(value,Max));
                Notify();
            }
        }
        public void Register(IObserver observer)
        {
            observers.Add(observer);
            observer.Update();
        }

        private void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].Update();
            }
        }
    }
}
