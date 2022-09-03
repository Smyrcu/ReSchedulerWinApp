using System;
using System.Windows;
using System.Windows.Input;
using ReSchedulerApp.ViewModels;
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
            CustomerViewModel viewModel = new CustomerViewModel();
            viewModel.SearchButton(SearchTextBox.Text);
        }

        private void SearchTextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextBox.Text == "Search...")
                SearchTextBox.Text = string.Empty;
            SearchTextBox.SelectAll();
        }
    }
}
