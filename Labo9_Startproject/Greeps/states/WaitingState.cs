using Greeps.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Greeps.States
{
    public class WaitingState : AGreepState
    {
        public WaitingState(Greep greep) : base(greep)
        {
        }

        public override void Act()
        {
            if (greep.NearbyGreep())
            {
                greep.State = new ReturningState(greep);
            }
        }
    }
}
