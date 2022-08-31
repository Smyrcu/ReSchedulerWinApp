using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ReSchedulerApp
{
    public class Constants
    {
        private  string API_BASE;
        private  string USER;
        private  string ACCOUNT_LOGIN;
        private  string ACCOUNT_REGISTER;
        private  string DAY_SCHEDULE;
        private  string SET_SCHEDULE;
        private  string SET_SCHEDULE_ID; // add id at the end
        private  string USER_BY_ID; // add id at the end
        private  string TEST;
        private  string TEST_USERS;
        private  string LOGGED;

        public Constants()
        {
            API_BASE = "https://rescheduller-api.azurewebsites.net/api";
            USER = API_BASE + "/users";
            ACCOUNT_LOGIN = API_BASE + "/account/login";
            ACCOUNT_REGISTER = API_BASE + "/account/register";
            DAY_SCHEDULE = API_BASE + "/schedule";
            SET_SCHEDULE = API_BASE + "/setSchedule";
            SET_SCHEDULE_ID = API_BASE + "/setSchedule/"; // add id at the end
            USER_BY_ID = API_BASE + "/users/"; // add id at the end
            TEST = API_BASE + "/test";
            TEST_USERS = API_BASE + "/test/users";
            LOGGED = API_BASE + "/users/logged";
        }

        public  string GetApiBase() => API_BASE;
        public  string GetUser() => USER;
        public  string GetAccountLogin() => ACCOUNT_LOGIN;
        public  string GetAccountRegister() => ACCOUNT_REGISTER;
        public  string GetDaySchedule() => DAY_SCHEDULE;
        public  string GetSetSchedule() => SET_SCHEDULE;
        public  string GetSetScheduleId(int id) => SET_SCHEDULE_ID + id;
        public  string GetUserById(int id) => USER_BY_ID + id;
        public  string GetTest() => TEST;
        public  string GetTestUsers() => TEST_USERS;
        public  string GetLogged() => LOGGED;
        

    }
}
