using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ReSchedulerApp.ApiConnection;
using ReSchedulerApp.Models;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;

namespace ReSchedulerApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly User _user;
        private readonly UserService userService;

        public MainView()
        {
            /*string Token = Thread.CurrentPrincipal.Identity.Name;
            userService = new UserService(Token);
            userService.GetUser(Token);
            _user = userService.GetActualUser();*/
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ControlBarPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void ControlBarPanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
    }
}
