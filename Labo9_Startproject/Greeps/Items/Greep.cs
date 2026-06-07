using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Greeps.Items
{
    public class Greep : AItem
    {
        static readonly Random random = new Random();

        readonly GreepsWorld world;

        const double STEP_SIZE = 10; // lengte waarover gestapt wordt

        // afbeelding greep zonder tomaat
        readonly string imageWithoutTomato;
        // afbeelding greep met tomaat
        readonly string imageWithTomato = "images/greep-with-food.png";

        public bool HasTomato { get { return ImageFile == imageWithTomato; } }
        public Greep(GreepsWorld world) : base("greep", 30)
        {
            this.world = world;
            Angle = random.Next(360); // beweegt in willekeurige richting

            // afbeelding greep zonder tomaat instellen
            imageWithoutTomato = ImageFile;

        }

        public override void Act()
        {
            Point pNext = GetNextPoint();
            if (HasTomato)
            {
                if (AtShip())
                {
                    ImageFile = imageWithoutTomato; // figuur wisselen naar figuur zonder tomaat
                }
                else
                {
                    if (world.AtEdge(pNext))
                    {
                        Angle += 180; //maak rechtsomkeer
                    }
                    else
                    {
                        if (!world.IsWater(pNext))
                        {
                            Location = pNext; // ga vooruit
                        }
                        else
                        {
                            Angle += 180;// maak rechtsomkeer
                        }
                    }
                }
            }
            else if (NearbyTomato())
            {
                if (NearbyGreep())
                {
                    ImageFile = imageWithTomato; // wisselen van figuur
                    Angle = GetAngle(world.Ship);
                }
            }
            else
            {
                Angle += random.Next(9) - 4; // draai een beetje naar links of naar rechts

                if (world.AtEdge(pNext))
                {
                    Angle += 180; //maak rechtsomkeer

                }
                else
                {
                    if (!world.IsWater(pNext))
                    {
                        Location = pNext;
                    }
                    else
                    {
                        Angle += 180;// maak rechtsomkeer
                    }
                }
            }
        }


        //What is the next position of the Greep
        private Point GetNextPoint()
        {
            double newX = Location.X + STEP_SIZE * Math.Cos((Angle) * Math.PI / 180);
            double newY = Location.Y + STEP_SIZE * Math.Sin((Angle) * Math.PI / 180);
            return new Point(newX, newY);
        }

        public bool NearbyTomato()
        {
            return world.NearbyTomato(this);
        }

        public bool NearbyGreep()
        {
            return world.NearbyGreep(this);
        }

        public bool AtShip()
        {
            return world.AtShip(this);

        }

        private double GetAngle(AItem target)
        {
            double dx = target.Location.X - Location.X;
            double dy = target.Location.Y - Location.Y;
            return Math.Atan2(dy, dx) * 180 / Math.PI;
        }
    }
}
