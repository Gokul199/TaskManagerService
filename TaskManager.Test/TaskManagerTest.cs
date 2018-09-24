using System;
using TaskManager.EntityModel;
using System.Collections.Generic;
using TaskManager.API;
using TaskManager.API.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using NUnit.Framework;

namespace TaskManager.Test
{
    [TestFixture]
    public class TaskManagerTest
    {

        [Test,Order(1)]
        public void AddTask()
        {

           TaskData lstTaskData = new TaskData()
            {                                
                    TaskID=1,
                    Task="First Task",
                    ParentID=0,
                    ParentTask="Parent Task 1",
                    Priority=1,
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(10)                
            };
            var controller = new TaskController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.AddTask(lstTaskData).StatusCode.ToString());
        }

        [Test,Order(2)]
        public void GetAllTasks()
        {
            List<TaskData> lstTaskData = new List<TaskData>()
            {
                new TaskData()
                {
                    TaskID=1,
                    Task="First Task",
                    ParentID=0,
                    ParentTask="Parent Task 1",
                    Priority=1,
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(10)
                },                
            };

            var controller = new TaskController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<TaskData> Respons =controller.Get().ToList();

            Assert.AreEqual(Respons.Count, lstTaskData.Count);
            if (Respons.Count == lstTaskData.Count)
            {
                Assert.AreEqual(Respons[0].TaskID, lstTaskData[0].TaskID);
                Assert.AreEqual(Respons[0].Task, lstTaskData[0].Task);
                Assert.AreEqual(Respons[0].ParentTask, lstTaskData[0].ParentTask);
                Assert.AreEqual(Respons[0].StartDate.Date, lstTaskData[0].StartDate.Date);
                Assert.AreEqual(Respons[0].EndDate.Date, lstTaskData[0].EndDate.Date);
            }
        }

        [Test,Order(3)]
        public void UpdateTask()
        {
            TaskData lstTaskData =            
                new TaskData
                {
                    TaskID=1,
                    Task="First Task Updated",
                    ParentID=0,
                    ParentTask="Parent Task 1",
                    Priority=10,
                    StartDate=DateTime.Now.AddDays(3),
                    EndDate=DateTime.Now.AddDays(13)                
            };

            var controller = new TaskController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Assert.AreEqual("OK", controller.EditTask(lstTaskData.TaskID, lstTaskData).StatusCode.ToString());

        }

        [Test,Order(4)]
        public void DeleteTask()
        {
            int DeleteID = 1;
            var controller = new TaskController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Assert.AreEqual("OK", controller.DeleteTask(DeleteID).StatusCode.ToString());

        }
    }
}
