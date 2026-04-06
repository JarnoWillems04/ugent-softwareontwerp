using System;
using System.Collections.Generic;
using System.Text;

namespace Tekenproject.Pattern
{

    class CommandInvoker
    {
        Stack<ICommando> commandlijst = new();
        Stack<ICommando> redolijst = new();
        public void Execute(ICommando command)
        {
            commandlijst.Push(command);
            command.Execute();
            redolijst = new();
        }

        public void Undo()
        {
            if (commandlijst.Count() > 0)
            {
                ICommando last = commandlijst.Pop();
                redolijst.Push(last);
                last.Undo();
            }
        }

        public void Redo()
        {
            if (redolijst.Count() > 0)
            {
                ICommando last = redolijst.Pop();
                last.Redo();
                commandlijst.Push(last);
            }
        }
    }
}
