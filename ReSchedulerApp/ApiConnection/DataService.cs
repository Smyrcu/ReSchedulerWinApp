using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ApiConnection
{
    public class DataService : IDataService
    {
        //Fields
        private Constants _constants;

        //Constructors
        public DataService()
        {
            _constants = new Constants();
        }

        //Methods

        public IEnumerable<User> GetAllUsers(string token)
        {
            IEnumerable<User> result;
            HttpClient client = new HttpClient();
            Uri uri = new Uri(_constants.GetTestUsers());
            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response =  client.GetAsync(uri).Result;

            if (!response.IsSuccessStatusCode) 
                throw new Exception($"Error: {response}, Error status code: {response.StatusCode}");

            var json =  response.Content.ReadAsStringAsync().Result;
            result = JsonSerializer.Deserialize<IEnumerable<User>>(json);

            return result;
        }

        public IEnumerable<ScheduleModel> GetSchedules(string token)
        {
            throw new NotImplementedException();
        }
    }
}
