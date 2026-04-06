using System;
using System.Collections.Generic;
using System.Text;

namespace Tekenproject.Pattern
{
    public abstract class ACommand : ICommando
    {
        protected DrawLogic receiver;

        public ACommand(DrawLogic receiver)
        {
            this.receiver = receiver;        
        }

        public abstract void Execute();
        public abstract void Undo();
        public void Redo() 
        {
            Execute();    
        }

    }
}
