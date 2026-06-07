using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Greeps.States;

namespace Greeps.Items
{
    public class Greep : AItem
    {
        static readonly Random random = new();

        readonly GreepsWorld world;

        readonly string imageWithoutTomato;
        // afbeelding greep met tomaat
        readonly string imageWithTomato = "images/greep-with-food.png";

        const double STEP_SIZE = 10; // lengte waarover gestapt wordt

        public bool HasTomato { get { return ImageFile == imageWithTomato; } }

        public IGreepState State { get; set; }
        public Greep(GreepsWorld world) : base("greep", 30)
        {
            this.world = world;
            imageWithoutTomato = ImageFile;
            Start();

            State = new SearchingState(this);

        }

        public void Start()
        {
            Angle = random.Next(360); // beweegt in willekeurige richting
        }

        public override void Act()
        {
            State.Act();
        }

        public void ChangeImageBack()
        {
            ImageFile = imageWithoutTomato; // figuur wisselen naar figuur zonder tomaat
        }
        public void ChangeImage()
        {
            ImageFile = imageWithTomato; // wisselen naar figuur met tomaat
        }

        public void Wobble()
        {
            Angle += random.Next(10) - 4;
        }
        public void Move()
        {
            Location = GetNextPoint(); // ga vooruit
        }

        public void TurnABit()
        {
            Angle += random.Next(5) + 5;
        }

        public bool CanMove()
        {
            Point pNext = GetNextPoint();
            return !world.AtEdge(pNext) && !world.IsWater(pNext);

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

        public void TurnToShip()
        {
            Angle = GetAngle(world.Ship);
        }

        private double GetAngle(AItem target)
        {
            double dx = target.Location.X - Location.X;
            double dy = target.Location.Y - Location.Y;
            return Math.Atan2(dy, dx) * 180 / Math.PI;
        }
    }
}
