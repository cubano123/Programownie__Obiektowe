using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp20
{
    class PriorityTask : ITask
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public PriorityTask()
        {

        }

        public PriorityTask(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public PriorityTask(PriorityTask task)
        {
            this.Name = task.Name;
            this.Priority = task.Priority;
     
        }

        public override string ToString()
        {
            return $"{this.Priority}: {this.Name}";
        }
    }
}
