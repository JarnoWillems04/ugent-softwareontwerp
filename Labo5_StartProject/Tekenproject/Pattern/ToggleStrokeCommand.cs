using System;
using System.Collections.Generic;
using System.Text;

namespace Tekenproject.Pattern
{
    public class ToggleStrokeCommand : ACommand
    {

        public ToggleStrokeCommand(DrawLogic receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.StrokeNr++;
        }

        public override void Undo()
        {
            receiver.StrokeNr--;
        }
    }
}
