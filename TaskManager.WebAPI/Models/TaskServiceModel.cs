using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.WebAPI.Models
{
    /// <summary>
    /// Task Manager Model Class
    /// </summary>
    public class TaskServiceModel
    {
        /// <summary>
        /// Task ID
        /// </summary>
        public int Task_ID { get; set; }
        /// <summary>
        /// Parent task ID
        /// </summary>
        public int Parent__ID { get; set; }
        /// <summary>
        /// Task Description
        /// </summary>
        public string Task { get; set; }
        /// <summary>
        /// Task Start Date
        /// </summary>
        public System.DateTime Start_Date { get; set; }
        /// <summary>
        /// Task End Date
        /// </summary>
        public System.DateTime End_Date { get; set; }
        /// <summary>
        /// Task Prioriry
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Parent task Model
        /// </summary>
        public ParentTaskServiceModel Parent_Task { get; set; }
    }
}