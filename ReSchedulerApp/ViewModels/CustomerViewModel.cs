using System.Collections.Generic;
using System.Data;
using System.Threading;
using Caliburn.Micro;
using ReSchedulerApp.ApiConnection;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {

        private IDataService dataService;
        private IEnumerable<User> users;
        private DataView dataView { get; set; }
        public BindableCollection<User> _people;

        public BindableCollection<User> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public CustomerViewModel()
        {
            dataService = new DataService();
            users = dataService.GetAllUsers(Thread.CurrentPrincipal.Identity.Name);
            People = new BindableCollection<User>(users);
        }
    }
}
