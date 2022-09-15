using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using ReSchedulerApp.CustomControls;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ViewModels
{
    public class AddScheduleViewModel : ViewModelBase
    {
        //Dev
        //Fields
        public List<User> _users { get; set; }
        public BindableCollection<User> _myItems;
        public ICommand AddSearchItem { get; }
        public BindableCollection<string> _searchItems;

        //Properties

        public List<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public BindableCollection<User> MyItems
        {
            get => _myItems;
            set
            {
                _myItems = value;
                OnPropertyChanged(nameof(MyItems));
            }
        }

        public BindableCollection<string> SearchItems
        {
            get => _searchItems;
            set
            {
                _searchItems = value;
                OnPropertyChanged(nameof(SearchItems));
            }
        }
        public AddScheduleViewModel()
        {
            //Dev
            var testValues = new TestValues();
            //
            _users = testValues.UserList;
            MyItems = new BindableCollection<User>(_users);
            SearchItems = new BindableCollection<string>
            {
                "Test1",
                "Test2",
                "Test3"
            };
        }

    }
}
