using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReSchedulerApp.Models
{
    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserLoginModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }


        public string toJSON()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }
    }
}
