using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ReSchedulerApp.ApiConnection;
using ReSchedulerApp.Models;

namespace ReSchedulerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserModel userModel;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }

        }

        public MainViewModel()
        {
            userModel = new UserService(new User());
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();


        }

        private void LoadCurrentUserData()
        {
            string Token = Thread.CurrentPrincipal.Identity.Name;
            userModel.DisplayUserInfo(Token);

            var user = userModel.GetActualUser();
            if (user != null)
            {
                CurrentUserAccount.Username = user.Email;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.Surname}";
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
