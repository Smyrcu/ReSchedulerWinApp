using System.Windows;
using System.Windows.Input;
using UserControl = System.Windows.Controls.UserControl;

namespace ReSchedulerApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            PeopleGrid.Items.Refresh();
        }

        private void SearchTextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextBox.Text == "Search...")
                SearchTextBox.Text = string.Empty;

            SearchTextBox.Select(0, SearchTextBox.Text.Length);
        }
    }
}
