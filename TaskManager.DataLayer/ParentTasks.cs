using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataLayer
{
    [Table("ParentTask")]
    public class ParentTasks
    {
        [Key]
        public int Parent_Id { get; set; }
        public string Parent_Task { get; set; }        
    }
}
