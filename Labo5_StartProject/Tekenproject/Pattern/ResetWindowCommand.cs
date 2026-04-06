using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tekenproject.Pattern
{
    public class ResetWindowCommand : ACommand
    {
        Stack<Shape> shapes = new();

        public ResetWindowCommand(DrawLogic receiver) : base(receiver) { }

        public override void Execute()
        {
            shapes = receiver.GetShapes();
            receiver.ClearCanvas();
        }

        public override void Undo()
        {
            foreach (Shape shape in shapes)
            {
                receiver.AddDrawing(shape);
            }
        }
    }
}
