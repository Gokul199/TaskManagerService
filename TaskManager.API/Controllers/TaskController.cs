using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.EntityModel;

namespace TaskManager.API.Controllers
{   
    public class TaskController : ApiController
    {
        TaskManagerBO TaskManagerBL = new TaskManagerBO();
        /// <summary>
        /// To Add a new task
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>        
        public HttpResponseMessage AddTask([FromBody]TaskData Task)
        {
            try
            {
                TaskManagerBL.AddTask(Task);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }            
        }

        /// <summary>
        /// To return task table data
        /// </summary>
        /// <returns>Task Table Data</returns>        
        public ICollection<TaskData> Get()
        {
            return TaskManagerBL.GetAllTasks();                       
        }

        public TaskData Get(int ID)
        {
            return TaskManagerBL.GetTask(ID);
        }
        [HttpPut]
        public HttpResponseMessage EditTask(int ID,[FromBody]TaskData Task)
        {
            try
            {
                TaskManagerBL.EditTask(ID,Task);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int ID)
        {
            try
            {
                TaskManagerBL.DeleteTask(ID);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }

    }
}
