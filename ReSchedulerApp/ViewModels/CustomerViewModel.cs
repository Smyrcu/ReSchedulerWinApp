using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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
        private string _searchText;
        private ObservableCollection<User> _people;

        //Properties
        public ObservableCollection<User> People
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

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public CustomerViewModel()
        {
            dataService = new DataService();
            users = dataService.GetAllUsers(Thread.CurrentPrincipal.Identity.Name);
            People = new BindableCollection<User>(users);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object obj)
        {
            SearchButton(SearchText);
        }

        //Commands
        public ICommand SearchCommand { get; }

        public void SearchButton(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
                People = new ObservableCollection<User>(users);

            List<User> newUsers = new List<User>();
            foreach (var user in users)
            {
                if (user.id != null && user.id.ToString().Contains(phrase))
                {
                    newUsers.Add(user);
                    continue;
                }

                if (user.name != null && user.name.Contains(phrase))
                {
                    newUsers.Add(user);
                    continue;
                }

                if (user.surname != null && user.surname.Contains(phrase))
                {
                    newUsers.Add(user);
                    continue;
                }

                if (user.phonenumber !=null && user.phonenumber.Contains(phrase))
                {
                    newUsers.Add(user);
                }
                    
                
            }

            People = new ObservableCollection<User>(newUsers);
        }
    }
}
