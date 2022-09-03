using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSchedulerApp.Models
{
    public class ScheduleModel
    {
        public int UserId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
