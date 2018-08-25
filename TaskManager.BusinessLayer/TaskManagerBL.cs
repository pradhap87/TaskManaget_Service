using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    public class TaskManagerBL
    {
        //DAL Context
        TaskManagerContext db = new TaskManagerContext();
        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Tasks task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }
        /// <summary>
        /// Get Task By Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public Tasks GetTaskById(int taskId)
        {
            Tasks t = new Tasks();
            t = db.Tasks.Find(taskId);
            return t;
        }
        /// <summary>
        /// Delete the task
        /// </summary>
        /// <param name="task"></param>
        public void DeleteTask(Tasks task)
        {
            db.Tasks.Attach(task);
            db.Tasks.Remove(task);
            db.SaveChanges();
        }
        /// <summary>
        /// Update the task
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(Tasks task)
        {
            db.Tasks.AddOrUpdate(task);
            db.SaveChanges();
        }
        /// <summary>
        /// Get all the task
        /// </summary>
        /// <returns></returns>
        public List<Tasks> GetTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            tasks = db.Tasks.ToList();
            return tasks;
        }
        /// <summary>
        /// Get Specific task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="parentTask"></param>
        /// <param name="priorityFrom"></param>
        /// <param name="priorityTo"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public List<Tasks> GetTask(String task, String parentTask, Int16 priorityFrom, Int16 priorityTo, DateTime startDate, DateTime endDate)
        {
            var tasks = db.Tasks.SqlQuery("select * from Task where (Task ='" + task + "' ) OR (Start_Date='" + startDate.ToLongDateString() + "') OR (End_Date = '" + endDate.ToLongDateString() + "') OR (Priority between " + priorityFrom.ToString() + " AND " + priorityTo.ToString() + ")").ToList();
            List<Tasks> lstTasks = new List<Tasks>();
            foreach (Tasks t in tasks)
            {
                lstTasks.Add(t);
            }
            return lstTasks;
        }
    }
}
