using System;
using System.Collections.Generic;
using System.Text;

namespace Tekenproject.Pattern
{
    public interface ICommando
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
