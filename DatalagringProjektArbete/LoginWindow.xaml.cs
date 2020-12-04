using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataBaseConnection;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }
        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                State.User = API.GetCustomerByName(SearchUserField.Text.Trim());
                if (State.User != null)
                {
                    var next_window = new MainWindow();
                    next_window.Show();
                    this.Close();
                }
                else
                {
                    SearchUserField.Text = "...";
                }
            }
        }
        private void LogInClick(object sender, RoutedEventArgs e)
        {
            State.User = API.GetCustomerByName(SearchUserField.Text.Trim());
            if (State.User != null)
            {
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
            }
            else
            {
                SearchUserField.Text = "...";
            }
        }

    }
}