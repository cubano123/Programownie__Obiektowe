using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Person
    {
        protected string name;
        protected int age;

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }
        public int Age
        { 
            get { return age; }
            set { age = value; }
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public bool Equals(Person? obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
