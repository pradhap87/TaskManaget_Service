using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.WebAPI.Models
{
    public class ParentTaskServiceModel
    {
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}