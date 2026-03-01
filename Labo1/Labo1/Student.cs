using System;
using System.Collections.Generic;
using System.Text;

namespace Labo1
{
    internal class Student : Person
    {
        private int id { get; set; }
        
        public Student(string name, int id) : base(name)
        {
            this.id = id;
        }

        public int Id()
        {
            return id;
        }

        public override string WelcomeMessage()
        {
            return base.WelcomeMessage() + ", and your id is " + this.id;
        }

        public override int GetInfo()
        {
            return this.id;
        }
    }
}
