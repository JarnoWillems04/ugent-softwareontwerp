using System;
using System.Collections.Generic;
using System.Text;

namespace Labo1
{
    internal abstract class Person
    {
        private string name { get; set; }

        public Person(string name)
        {
            this.name = name; 
        }

        public string Name { get { return name; } }

        public virtual string WelcomeMessage()
        {
            return $"Hello {this.name}";
        }

        public abstract int GetInfo();

    }
}
