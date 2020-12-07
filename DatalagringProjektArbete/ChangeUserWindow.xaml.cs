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
            if (OldUserName.Text == State.User.Username) // Om det gamla användarnamnet stämmer verens med användarnamnet i Table
            {
                if (NewUserName.Text == NewUserName.Text) // Om användarnamnet är lika med det nya användarnamnet.
                {
                    State.User.Username = NewUserName.Text;
                    API.ctx.Customers.Update(State.User); // Uppdaterar användarnamnet i tables-listan. 
                    API.ctx.SaveChanges();
                    MessageBox.Show("Username has changed!", "Username changed!", MessageBoxButton.OK, MessageBoxImage.Information); // SKriv ut meddelande.
                    var BackToMainWindow = new MainWindow();  // Automatiskt kommer man tillbaka till föregående fönster vid byta av användarnamn.     
                        BackToMainWindow.Show();
                        this.Close();
                }
            }
        }
        private void BackToMainButton(object sender, RoutedEventArgs e) //Vid kanpptryck så går man tillbaka till programmets föregående sida alltså, Main fönstret.
        {
            var BackToMain = new MainWindow(); // Vid tryck på Back-knappen så tas man tillbaka till föregående fönster. 
            BackToMain.Show();
            this.Close();
        }
    }
}
