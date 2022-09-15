using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using ReSchedulerApp.ApiConnection;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserModel userModel;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }

        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowAddScheduleViewCommand { get; }

        public MainViewModel()
        {
            userModel = new UserService(new User());
            CurrentUserAccount = new UserAccountModel();

            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowAddScheduleViewCommand = new ViewModelCommand(ExecuteShowAddScheduleViewModel);

            //Default view
            ExecuteShowHomeViewCommand(null);
            
            //LoadCurrentUserData();
        }

        private void ExecuteShowAddScheduleViewModel(object obj)
        {
            CurrentChildView = new AddScheduleViewModel();
            Caption = "Add Schedule";
            Icon = IconChar.CalendarPlus;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            string Token = Thread.CurrentPrincipal.Identity.Name;
            userModel.DisplayUserInfo(Token);

            var user = userModel.GetActualUser();
            if (user != null)
            {
                CurrentUserAccount.Username = user.email;
                CurrentUserAccount.DisplayName = $"{user.name} {user.surname}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                Application.Current.Shutdown();
            }
        }
    }
}
