using System.Windows;
using System.Windows.Documents;

namespace Greeps.Items
{
    public class GreepsWorld
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 600;
        private const int EDGE = 10;
        private const int TOMATO_COUNT = 10;
        private const int GREEP_COUNT = 40;

        public readonly System.Drawing.Bitmap Background = new(@"images/map.jpg");

        public Ship Ship { get; private set; }

        public List<AItem> Items { get; private set; }
        readonly Random random = new();

        public GreepsWorld()
        {
            Items = [];

            Ship = MakeShip();
            PlaceTomatos();
            PlaceGreeps();

            Items.Add(Ship); // wordt bovenaan gezet op Canvas
        }
        private Ship MakeShip()
        {
            // schip 
            Ship ship = new();
            Point location = GetPoint();
            // schip mag niet in het water staan
            while (IsWater(location))
                location = GetPoint();
            ship.Location = location;
            return ship;
        }

        private void PlaceTomatos()
        {
            // tomatenplanten
            for (int i = 0; i < TOMATO_COUNT; i++)
            {
                AItem im = new Tomato();
                Point location = GetPoint();
                // tomaten mogen niet in het schip of in water
                while (Distance(location, Ship.Location) < Ship.Size || IsWater(location))
                    location = GetPoint();
                im.Location = location;
                Items.Add(im);
            }
        }

        private void PlaceGreeps()
        {
            // greeps
            for (int i = 0; i < GREEP_COUNT; i++)
            {
                Greep g = new(this)
                {
                    Location = Ship.Location
                };
                Items.Add(g);

            }
        }

        public bool IsWater(Point p)
        {
            // Get the color of a pixel within myBitmap.
            System.Drawing.Color pixelColor = Background.GetPixel((int)p.X, (int)(p.Y));
            return pixelColor.B > pixelColor.R;
        }

        private Point GetPoint()
        { // willekeurige positie
            Point location = new()
            {
                X = EDGE + random.NextDouble() * (WIDTH - 2 * EDGE),
                Y = EDGE + random.NextDouble() * (HEIGHT - 2 * EDGE)
            };
            return location;

        }

        public bool AtEdge(Point p)
        {
            return p.X < EDGE || p.X > WIDTH - EDGE || p.Y < EDGE || p.Y > HEIGHT - EDGE;
        }

        public bool NearbyTomato(Greep greep)
        {
            foreach (AItem image in Items)
            {
                if (image is Tomato && Distance(greep.Location, image.Location) < greep.Size / 3)
                {
                    return true;
                }

            }
            return false;
        }

        public bool NearbyGreep(Greep greep)
        {
            foreach (AItem image in Items)
            {
                if (image != greep && image is Greep && Distance(greep.Location, image.Location) < greep.Size / 2)
                {
                    return true;
                }

            }
            return false;
        }

        public bool AtShip(Greep greep)
        {
            return Distance(Ship.Location, greep.Location) < Ship.Size / 3;
        }

        public double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

    }
}
