using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReSchedulerApp.Models;

namespace ReSchedulerApp
{
    public class TestValues
    {

        public List<User> UserList; 

        public TestValues()
        {
            UserList = CreateUsers();

        }

        private List<User> CreateUsers()
        {
            return new List<User>
            {
                new User
                {
                    id = 0,
                    email = "testuser0@gmail.com",
                    name = "Test0",
                    surname = "User0",
                    phonenumber = "000 000 000",
                    roleId = 1
                },

                new User
                {
                    id = 1,
                    email = "testuser1@gmail.com",
                    name = "Test1",
                    surname = "User1",
                    phonenumber = "111 111 111",
                    roleId = 1
                },

                new User
                {
                id = 2,
                email = "testuser2@gmail.com",
                name = "Test2",
                surname = "User2",
                phonenumber = "222 222 222",
                roleId = 1
                },

                new User
                {
                    id = 3,
                    email = "testuser3@gmail.com",
                    name = "Test3",
                    surname = "User3",
                    phonenumber = "333 333 333",
                    roleId = 1
                },

                new User
                {
                    id = 4,
                    email = "testuser4@gmail.com",
                    name = "Test4",
                    surname = "User4",
                    phonenumber = "444 444 444",
                    roleId = 1
                },

                new User
                {
                    id = 5,
                    email = "testuser5@gmail.com",
                    name = "Test5",
                    surname = "User5",
                    phonenumber = "555 555 555",
                    roleId = 1
                },

                new User
                {
                    id = 6,
                    email = "testuser6@gmail.com",
                    name = "Test6",
                    surname = "User6",
                    phonenumber = "666 666 666",
                    roleId = 1
                },

                new User
                {
                    id = 7,
                    email = "testuser7@gmail.com",
                    name = "Test7",
                    surname = "User7",
                    phonenumber = "777 777 777",
                    roleId = 1
                },

                new User
                {
                    id = 8,
                    email = "testuser8@gmail.com",
                    name = "Test8",
                    surname = "User8",
                    phonenumber = "888 888 888",
                    roleId = 1
                },

                new User
                {
                    id = 9,
                    email = "testuser9@gmail.com",
                    name = "Test9",
                    surname = "User9",
                    phonenumber = "999 999 999",
                    roleId = 1
                }

            };
        }
    }
}
