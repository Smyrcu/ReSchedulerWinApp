using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ReSchedulerApp.Models;
using static System.Int32;

namespace ReSchedulerApp.ApiConnection
{
    public class UserService : IUserModel
    {
        private User _user;
        private readonly Constants constants;

        public UserService()
        {
            _user = new User();
            constants = new Constants();
        }

        public UserService(User user)
        {
            _user = user; 
            constants = new Constants();
        }

        public UserService(string token)
        {
            _user = new User();
            _user.token = token;
            constants = new Constants();
        }


        public bool LoginUser(UserLoginModel userLoginModel)
        {
            _user.token = GetLoginToken(userLoginModel);
            if (_user.token == null) return false;
            // GetUser(_user.Token);
            //
            // _user.role = new Role(_user.RoleId);

            return true;
        }

        public User DisplayUserInfo(string token)
        {
            GetUser(token);
            _user.role = new Role(_user.roleId);
            return _user;
        }

        public string GetLoginToken(UserLoginModel userLoginModel)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(constants.GetAccountLogin());

                //var newPost = new UserLoginModel("pan.smierci12@gmail.com", "Admin123");
                var newPost = userLoginModel;
                var newPostJson = JsonSerializer.Serialize(newPost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = client.PostAsync(uri, payload).Result.Content.ReadAsStringAsync().Result;
                if (result is "Something went wrong" or "Invalid username or password") return null;
                return result;
            }
        }

        public void GetUser(string token)
        {
            if (string.IsNullOrEmpty(token)) return;

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(constants.GetLogged());

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var newPost = token;
                var newPostJson = JsonSerializer.Serialize(newPost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = client.PostAsync(uri, payload).Result.Content.ReadAsStringAsync().Result;
                JsonObject jsonObject = new JsonObject();
                jsonObject = JsonSerializer.Deserialize<JsonObject>(result) ?? throw new Exception("Wrong result!");
                _user.id = Parse(jsonObject["value"]!.ToString());
            }

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(constants.GetUserById(_user.id));

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var result = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

                JsonObject json = new JsonObject();
                json = JsonSerializer.Deserialize<JsonObject>(result) ?? throw new Exception("Wrong result!");

                _user.name = json["email"]!.ToString();
                _user.name = json["name"]!.ToString();
                _user.surname = json["surname"]!.ToString();
                _user.roleId = Parse(json["roleId"]!.ToString());
            }
        }

        public User GetActualUser() => _user;


        public bool AuthenticateUser(NetworkCredential networkCredential)
        {
            var logged= LoginUser(new UserLoginModel(networkCredential.UserName, networkCredential.Password));
            return logged;
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
