using Greeps.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Greeps.States
{
    public abstract class AGreepState : IGreepState
    {

        protected Greep greep;
        public AGreepState(Greep greep)
        {
            this.greep = greep;
        }
        public abstract void Act();

    }
}
