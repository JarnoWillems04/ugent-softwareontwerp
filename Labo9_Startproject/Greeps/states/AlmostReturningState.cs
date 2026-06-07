using Greeps.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeps.States
{
    public class AlmostReturningState : AGreepState
    {
        int counter = 0;
        const int MAX = 10;

        public AlmostReturningState(Greep greep) : base(greep)
        {
        }

        public override void Act()
        {
            if (greep.CanMove())
            {
                greep.Move();
                counter++;
                if (counter == MAX)
                {
                    greep.State = new ReturningState(greep);
                }
            }
            else
            {
                greep.State = new TurningState(greep);

            }
        }
    }
}
