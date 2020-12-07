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


namespace Store
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            AccountInfoLabel.Content = //Skriver ut ett meddelande när man går in på sin profil och kan se vad det är man har hyrt för filmer. 
                "Hi, " + State.User.Firstname + "!\nHere's what you've rented in the past: ";


            int y = 0;
            for (int i = 0; i < State.User.Sales.Count; i++) // För varje varv så öka hyrda filmer som har hyrts. 
            {
                Rental rental = State.User.Sales[i];

                var rental1 = new Label() { }; 
                rental1.Content = rental.Movie.Title;
                rental1.HorizontalAlignment = HorizontalAlignment.Left; //Lite designe.
                rental1.VerticalAlignment = VerticalAlignment.Top;
                rental1.Foreground = Brushes.White;
                rental1.Margin = new Thickness(0, y, 0, 0);
                Rentals.Children.Add(rental1);
                y += 25;
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e) // Return to MainWindow.
        {
            var BackToMainWindow = new MainWindow(); // Vid tryck på Return-knappen så tas man tillbaka till föregående fönster i programmet. 
            {
                BackToMainWindow.Show(); 
                this.Close();
            }
        }

        private void Window_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void ChangeUserName(object sender, RoutedEventArgs e) // Knappens funktion
        {
            var ToChangeUserWindow = new ChangeUserWindow(); // Vid tryck på change user name-knappen så tas man till ett nytt fönster där man kan byta användarnamn. 
            ToChangeUserWindow.Show();
            this.Close();
        }
    }
}
