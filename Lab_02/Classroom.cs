using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Classroom
    {
        private string _name;
        private Person[] _persons;
        public string Name { get; set; }
        public Classroom(string name, Person[] persons)
        {
            this.Name = name;
            this._persons = persons;
        }
        public override string ToString()
        {
            string cr = $"Classroom: {Name} \n";
            foreach(Person person in _persons)
            {
                cr += "\n" + person.ToString() + "\n";
            }
            return cr;
        }

    }
}
