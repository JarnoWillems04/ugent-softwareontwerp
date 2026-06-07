using Greeps.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeps.States
{
    public class SearchingState : AGreepState
    {
        public SearchingState(Greep greep) : base(greep)
        {
        }

        public override void Act()
        {
            if (greep.NearbyTomato())
                greep.State = new WaitingState(greep);
            else
            {
                greep.Wobble();
                if (greep.CanMove())
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
}
