using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReSchedulerApp.Models
{
    public interface IUserModel
    {
        bool AuthenticateUser(NetworkCredential networkCredential);
        User GetActualUser();
        IEnumerable<User> GetAllUsers();

    }
}
