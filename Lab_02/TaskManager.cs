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
    }
}
