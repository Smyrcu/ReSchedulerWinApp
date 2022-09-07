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
            get
            {
                return _myItems;
            }
            set
            {
                _myItems = value;
                OnPropertyChanged(nameof(MyItems));
            }
        }

        public AddScheduleViewModel()
        {
            //Dev
            var testValues = new TestValues();
            //
            _users = testValues.UserList;
            MyItems = new BindableCollection<User>(_users);

        }

    }
}
