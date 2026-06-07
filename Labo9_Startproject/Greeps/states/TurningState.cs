using Greeps.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeps.States
{
    public class TurningState : AGreepState
    {
        public TurningState(Greep greep) : base(greep)
        {

        }

        public override void Act()
        {
            if (!greep.CanMove())
            {
                greep.TurnABit();
            }
            else
            {
                if (greep.HasTomato)
                    greep.State = new AlmostReturningState(greep);
                else
                    greep.State = new SearchingState(greep);
            }
        }
    }
}
