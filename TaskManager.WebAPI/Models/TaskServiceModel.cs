using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.WebAPI.Models
{
    public class TaskServiceModel
    {
        public int Task_ID { get; set; }
        public int Parent__ID { get; set; }
        public string Task { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public int Priority { get; set; }

        public ParentTaskServiceModel Parent_Task { get; set; }
    }
}