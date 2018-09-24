using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.EntityModel;


namespace TaskManager.DataLayer
{
    public class TaskManagerDAL
    {
        public void AddTask(TaskData Task)            
        {
            int ParentID = 0;
            using (var ct = new TaskManagerContext())
            {                     
                ParentID = Convert.ToInt32((from r in ct.ParentTaskData where r.ParentTask == Task.ParentTask select ParentID).FirstOrDefault());
                if (ParentID == 0)
                {
                    ParentTaskData parent = new ParentTaskData();
                    parent.ParentTask = Task.ParentTask;
                    ct.ParentTaskData.Add(parent);
                    ct.SaveChanges();
                }
                Task.ParentID = ParentID;
                ct.TaskData.Add(Task);
                ct.SaveChanges();
            }
        }
        public void UpdateTask(int ID,TaskData Task)
        {
            int ParentID = 0;
            using (var ct = new TaskManagerContext())
            {                
                var UpdTask = ct.TaskData.Where(a => a.TaskID == ID).FirstOrDefault();
                UpdTask.Task = Task.Task;
                UpdTask.ParentID = ParentID;
                UpdTask.ParentTask = Task.ParentTask;
                UpdTask.Priority = Task.Priority;
                UpdTask.StartDate = Task.StartDate;
                UpdTask.EndDate = Task.EndDate;                
                ct.SaveChanges();
            }
        }
        public List<TaskData> GetAllTasks()
        {
            List<TaskData> TaskDetails = new List<TaskData>();
            using (var ct = new TaskManagerContext())
            {
                TaskDetails = (from r in ct.TaskData select r).ToList<TaskData>();
            }
            return TaskDetails;
        }

        public TaskData GetTask(int ID)
        {
            TaskData TaskDetail = new TaskData();
            using (var ct = new TaskManagerContext())
            {
                TaskDetail = ct.TaskData.Where(a => a.TaskID == ID).FirstOrDefault();
            }
            return TaskDetail;
        }
        public void DeleteTask(int ID)
        {
            using (var ct = new TaskManagerContext())
            {
                List<TaskData> DelTask = new List<TaskData>();
                DelTask = (from r in ct.TaskData select r).ToList<TaskData>();
                if (DelTask != null && DelTask.Count != 0)
                {
                    ct.TaskData.Remove(DelTask[0]);
                    ct.SaveChanges();
                }
            }
        }
    }
}
