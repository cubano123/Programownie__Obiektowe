using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp20
{
    class TaskManager
    {
        private List<ITask> waitingTasks;
        private List<ITask> finishedTasks;

        public void AddTask(ITask task)
        {
            waitingTasks.Add(task);
        }

        public void AddTask(string name, int priority, string description)
        {
            waitingTasks.Add(new DescribedTask(name, priority, description));

            TaskAdded.Invoke();
        }

        public void FinishTask(int index)
        {
            var t = waitingTasks[index];

            waitingTasks.Remove(t);
            finishedTasks.Add(t);

            TaskFinished.Invoke();
        }

        public override string ToString()
        {
            string info = "Waiting:\n";

            foreach (ITask task in waitingTasks)
            {
                info += task + "\n";
            }

            info += "Finished:\n";

            foreach (ITask task in finishedTasks)
            {
                info += task + "\n";
            }

            return info;
        }

        public delegate void Del();

        public event Del TaskAdded;
        public event Del TaskFinished;

    }
}
