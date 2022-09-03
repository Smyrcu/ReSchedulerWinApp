using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ApiConnection
{
    public interface IDataService
    {
        IEnumerable<User> GetAllUsers(string token);
        IEnumerable<ScheduleModel> GetSchedules(string token);
    }
}
