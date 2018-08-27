using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.DataLayer;
using TaskManager.WebAPI.Models;
using System.Web.Http.Cors;

namespace TaskManager.WebAPI.Controllers
{
    /// <summary>
    /// Task Manager Service
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController
    {
        TaskManagerBL taskBL = new TaskManagerBL();
        /// <summary>
        /// Get All the Tasks
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public List<Tasks> GetTasks()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            List<Tasks> tasks = new List<Tasks>();
            try
            {
                tasks = taskBL.GetTasks();
            }
            catch
            { return tasks; }
            return tasks;
        }

        /// <summary>
        /// Get task by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            Tasks task = new Tasks();
            task = taskBL.GetTaskById(id);
            if (task != null)
                return Ok(task);
            else
                return StatusCode(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Get Task based on the input parameters 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="parentTask"></param>
        /// <param name="priorityFrom"></param>
        /// <param name="priorityTo"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>        
        [HttpGet]
        public List<Tasks> GetTaskbyFilter(String task, String parentTask, Int16 priorityFrom, Int16 priorityTo, DateTime? startDate, DateTime? endDate)
        {
            List<Tasks> tasks = new List<Tasks>();
            try
            {
                if (startDate == null)
                {
                    startDate = DateTime.Now;
                }
                if (endDate == null)
                {
                    endDate = DateTime.Now;
                }

                tasks = taskBL.GetTask(task, parentTask, priorityFrom, priorityTo, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
            }
            catch
            {
                return tasks;
            }
            return tasks;
        }

        /// <summary>
        /// Add new Task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="parentTask"></param>
        /// <param name="priority"></param>        
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult AddTask(String task, int? parentTask, Int16 priority, DateTime startDate, DateTime endDate)
        {
            DataLayer.Tasks t = new Tasks();
            try
            {
                t.Task = task;
                t.Parent__ID = parentTask;
                t.Priority = priority;
                t.Start_Date = startDate;
                t.End_Date = endDate;

                taskBL.AddTask(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.Created);
        }
        /// <summary>
        /// Update the Task information
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdateTask(DataLayer.Tasks t)
        {
            try
            {
                taskBL.UpdateTask(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteTask(DataLayer.Tasks t)
        {
            try
            {
                taskBL.DeleteTask(t);
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
