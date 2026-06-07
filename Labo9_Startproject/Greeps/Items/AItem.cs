using System.Windows;

namespace Greeps.Items
{
    public abstract class AItem
    {
        // positie op canvas
        public Point Location { get; set; }

        // bestand afbeelding op canvas
        public string ImageFile { get; protected set; }

        // grootte op canvas
        public int Size { get; private set; }

        public double Angle { get; protected set; }

        public AItem(string type, int size)
        {
            Size = size;
            Location = new Point();
            ImageFile = $"images\\{type}.png"; 
        }

        public abstract void Act();
    }
}
