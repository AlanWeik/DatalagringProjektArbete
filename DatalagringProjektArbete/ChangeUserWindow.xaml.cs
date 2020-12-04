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
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using DataBaseConnection;
namespace Store
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChangeUserWindow : Window
    {
        public ChangeUserWindow()
        {
            InitializeComponent();
        }
        private void ChangeUserNameButton(object sender, RoutedEventArgs e) // Byter användarnamnet 
        {
            if (OldUserName.Text == State.User.Username)
            {
                if (NewUserName.Text == NewUserName.Text)
                {
                    State.User.Username = NewUserName.Text;
                    API.ctx.Customers.Update(State.User);
                    API.ctx.SaveChanges();
                    MessageBox.Show("Username has changed!", "Username changed!", MessageBoxButton.OK, MessageBoxImage.Information);
                    var BackToMainWindow = new MainWindow();                 
                        BackToMainWindow.Show();
                        this.Close();
                }
            }
        }
        private void BackToMainButton(object sender, RoutedEventArgs e)
        {
            var BackToMain = new MainWindow();
            BackToMain.Show();
            this.Close();
        }
    }
}
