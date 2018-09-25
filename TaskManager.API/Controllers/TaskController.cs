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
        /// <param name="task"></param>
        /// <returns></returns>        
        public HttpResponseMessage AddTask([FromBody]TaskData task)
        {
            try
            {
                TaskManagerBL.AddTask(task);
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

        public TaskData Get(int id)
        {
            return TaskManagerBL.GetTask(id);
        }
        [HttpPut]
        public HttpResponseMessage EditTask(int id,[FromBody]TaskData task)
        {
            try
            {
                TaskManagerBL.EditTask(id,task);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            try
            {
                TaskManagerBL.DeleteTask(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }

    }
}
