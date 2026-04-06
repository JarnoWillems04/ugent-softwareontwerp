using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tekenproject.Pattern
{
    public class DrawCommand : ACommand
    {
        Shape shape;

        public DrawCommand(DrawLogic receiver, Shape shape): base(receiver)
        {
            this.shape = shape;
        }

        public override void Execute()
        {
            receiver.AddDrawing(shape);
        }

        public override void Undo()
        {
            receiver.RemoveLast();
        }
    }
}
