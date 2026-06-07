using System;
using System.Collections.Generic;
using System.Text;

namespace Bestanden
{
    public class User
    {
        bool isAdmin { get; set; }

        public User(bool isAmdin)
        {
            this.isAdmin = isAmdin;
        }
    }
}
