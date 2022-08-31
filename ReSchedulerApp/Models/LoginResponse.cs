using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSchedulerApp.Models
{
    public class LoginResponse
    {
        private string token { get; }
        private int userId { get; }

        public LoginResponse(string token, int userId)
        {
            this.token = token;
            this.userId = userId;
        }

    }
}
