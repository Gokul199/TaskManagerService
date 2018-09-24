using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.EntityModel;

namespace TaskManager.BusinessLayer
{
    public class TaskManagerBO
    {
        //Create a new instance of Task
        TaskManagerDAL TaskManagerDL = new TaskManagerDAL();
        public List<TaskData> GetAllTasks()
        {
            return TaskManagerDL.GetAllTasks();
        }

        public TaskData GetTask(int ID)
        {
            return TaskManagerDL.GetTask(ID);
        }
        public void AddTask(TaskData Task)
        {
            TaskManagerDL.AddTask(Task);
        }
        public void DeleteTask(int TaskID)
        {
            TaskManagerDL.DeleteTask(TaskID);
        }
        public void EditTask(int ID,TaskData Task)
        {
            TaskManagerDL.UpdateTask(ID,Task);
        }
    }
}
