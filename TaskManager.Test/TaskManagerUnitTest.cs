using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.WebAPI.Controllers;
using TaskManager.WebAPI.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using TaskManager.DataLayer;
using System.Net;

namespace TaskManager.Test
{
    [TestClass]
    public class TaskManagerUnitTest
    {
        /// <summary>
        /// Test Method For selecting all the Tasks
        /// </summary>
        [TestMethod]
        public void TestGetTasks()
        {
            var apiController = new TaskManagerController();
            var result = apiController.GetTasks();
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test Method For selecting the Tasks with TaskID.
        /// </summary>
        [TestMethod]
        public void TestGetTask()
        {
            var apiController = new TaskManagerController();
            apiController.Request = new HttpRequestMessage();
            apiController.Configuration = new HttpConfiguration();

            IHttpActionResult actionResult = apiController.GetTaskById(8);
            if (((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode != HttpStatusCode.NotFound)
            {
                var contentResult = actionResult as OkNegotiatedContentResult<Tasks>;
                Assert.IsNotNull(contentResult);
                Assert.AreEqual(8, contentResult.Content.Task_ID);
            }
        }
        /// <summary>
        /// Test Method for adding one new Task
        /// </summary>
        [TestMethod]
        public void TestAddTask()
        {
            var apiController = new TaskManagerController();
            IHttpActionResult actionResult = apiController.AddTask("FSD Capsule", null, 10, Convert.ToDateTime("2018-08-08"), Convert.ToDateTime("2018-10-10"));
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Created, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method for Get task by filter
        /// </summary>
        [TestMethod]
        public void TestGetTaskByFilters()
        {
            var apiController = new TaskManagerController();
            var result = apiController.GetTaskbyFilter("FSD Capsule", null, 10, 30, Convert.ToDateTime("2018-08-08"), Convert.ToDateTime("2018-10-10"));
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// TestMethod for uding the task
        /// </summary>
        [TestMethod]
        public void TestUpdateTask()
        {
            var apiController = new TaskManagerController();
            DataLayer.Tasks t = new Tasks();
            t.Task = "FSD Capsule";
            t.Parent__ID = null;
            t.Priority = 22;
            t.Start_Date = Convert.ToDateTime("2018-08-08");
            t.End_Date = Convert.ToDateTime("2018-11-11");
            IHttpActionResult actionResult = apiController.UpdateTask(t);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method for Delete Task
        /// </summary>
        [TestMethod]
        public void TestDeleteTask()
        {
            var apiController = new TaskManagerController();
            DataLayer.Tasks t = new Tasks();
            t.Task_ID = 9;
            t.Task = "FSD Capsule";
            t.Parent__ID = null;
            t.Priority = 22;
            t.Start_Date = Convert.ToDateTime("2018-08-08");
            t.End_Date = Convert.ToDateTime("2018-11-11");
            IHttpActionResult actionResult = apiController.DeleteTask(t);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
