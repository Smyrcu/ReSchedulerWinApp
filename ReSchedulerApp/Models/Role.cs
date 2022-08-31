using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReSchedulerApp.Exceptions;

namespace ReSchedulerApp.Models
{
    public class Role
    {
        private int roleId { get; }
        private string roleName { get; }

        public Role(int roleId)
        {
            this .roleId = roleId;

            roleName = roleId switch
            {
                1 => "User",
                2 => "Manager",
                3 => "Admin",
                _ => throw new WrongRoleIdException()
            };
        }
    }
}
