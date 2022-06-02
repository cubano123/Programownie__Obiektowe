using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Task
    {
        private string _name;
        private TaskStatus _status;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public TaskStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Task(string name, TaskStatus status)
        {
            this.Name = name;
            this.Status = status;
        }
        public override string ToString()
        {
            return $"{Name} [{Status}]";
        }
        public bool Equals(Task? obj)
        {
            return base.Equals(obj);
        }
    }
}
