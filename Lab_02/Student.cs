using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Student : Person
    {
        protected string group;
        protected List<Task> tasks;

        public string Group { get; set; }

        public Student(string name, int age, string group) : base(name, age)
        {
            this.name = name;
            this.age = age;
            this.group = group;
            tasks = new List<Task>();
        }
        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.name = name;
            this.age = age;
            this.group = group;
            this.tasks = tasks;
        }
        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            Task task = new Task(taskName, taskStatus);
            tasks.Add(task);
        }
        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }
        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index].Status = taskStatus;
        }
        public string RenderTask(string prefix = "\t")
        {
            string pref = "Tasks: ";
            for (int i = 1; i <= tasks.Count; i++)
            {
                pref += $"\n{prefix} {i}. {tasks[i - 1]}";
            }
            return pref;
        }
        public override string ToString()
        {
            return $"Student: {this.name} ({this.age} y.o.) \nGroup: {group}\n{RenderTask(" ")}"; 
        }
        public bool Equals(Student? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true; ;
            if (!(obj is Student)) return false;

            return (this.name == obj.Name);
        }
        private bool SequenceEqual(List<Type> a, List<Type> b)
        {
            throw new NotImplementedException();
        }

    }
}
