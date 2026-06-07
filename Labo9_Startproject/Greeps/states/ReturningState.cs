using Greeps.Items;
using System.Windows;
namespace Greeps.States
{
    public class ReturningState : AGreepState
    {
        public ReturningState(Greep greep) : base(greep)
        {
            greep.TurnToShip();
            greep.ChangeImage(); // wisselen van figuur
        }

        public override void Act()
        {

            if (greep.AtShip())
            {
                greep.ChangeImageBack();
                greep.Start();
                // andere state
                greep.State = new SearchingState(greep);
            }
            else if (greep.CanMove())
            {
                greep.Move();
            }
            else
            {
                greep.State = new TurningState(greep);

            }
        }
    }
}
