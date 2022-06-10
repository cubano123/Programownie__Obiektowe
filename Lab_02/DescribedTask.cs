using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp20
{
    class DescribedTask : PriorityTask
    {
        public string Description { get; set; }

        public DescribedTask()
        {

        }

        public DescribedTask(string name, int priority, string description) : base(name,priority)
        {
            Description = description;
        }

        public DescribedTask(DescribedTask task)
        {
            this.Name = task.Name;
            this.Priority = task.Priority;
            this.Description = task.Description;
        }

        public override string ToString()
        {
            return $"{this.Priority}: {this.Name} {this.Description}";
        }

    }
}
