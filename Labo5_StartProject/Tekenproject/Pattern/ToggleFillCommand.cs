using System;
using System.Collections.Generic;
using System.Text;

namespace Tekenproject.Pattern
{
    public class ToggleFillCommand : ACommand
    {
        public ToggleFillCommand(DrawLogic receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.FillNr++;
        }

        public override void Undo()
        {
            receiver.FillNr--;
        }
    }
}
