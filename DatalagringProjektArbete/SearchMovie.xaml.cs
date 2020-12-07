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
    /// Interaction logic for SearchMovie.xaml
    /// </summary>
    public partial class SearchMovie : Window
    {
        public SearchMovie()
        {
            InitializeComponent();
            int y = 0;
            for (int i = 0; i < State.Movies.Count; i++)
            {
                var movie = State.Movies[i];

                var movieone = new Label() { };
                movieone.Content = movie.Title;
                movieone.HorizontalAlignment = HorizontalAlignment.Left;
                movieone.VerticalAlignment = VerticalAlignment.Top;
                movieone.Foreground = Brushes.White;
                movieone.Margin = new Thickness(0, y, 0, 0);
                ScrollViewrMovies.Children.Add(movieone);
                y += 25;
            }

         
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }
        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Om knapptryck är lika med ENTER
            {
                State.Movies.Clear();
                State.Movies.AddRange(API.GetMovieByName(SearchMovieField.Text));
                var next_searchMovie = new SearchMovie();
                next_searchMovie.Show();
                this.Close();

                if (State.Movies.Count == 0) // Om sökvärdet är lika med 0 eller blankt så skriv ut meddelandet.
                {
                    MessageBox.Show("No movie found", "please try again!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        // Vad som händer när man klickar på en filmikon i appen. AK BJÖRN
        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Ta reda på vilken kordinat den klickade bilden har.
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            //Används kordinaten för att ta reda på vilken motsvarande record det rör sig om.
            int i = y * ScrollViewrMovies.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            //Försök att registrera en uthyrdning.
            if (API.RegisterSale(State.User, State.Pick))
            {
                MessageBox.Show("Sale succeeded!", "Downloading your moive right now.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error occured while purchase was made.. Please try again later mate!", "Purchase failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void SearchClick(object sender, RoutedEventArgs e) // Söker efter filmerna genom state.movies samt API och skriver ut filmtext i search-bar.
        {
            {
                State.Movies.Clear();
                State.Movies.AddRange(API.GetMovieByName(SearchMovieField.Text));
                var next_searchMovie = new SearchMovie();
                next_searchMovie.Show();
                this.Close();

                if (State.Movies.Count == 0) // Om värdet är lika med 0 eller är blankt så skriv ut felmeddelande.
                {
                    MessageBox.Show("No movie found", "please try again!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void BackClick(object sender, RoutedEventArgs e) // Knappens funktion
        {
            var MainWindow = new LoginWindow(); // Vid klick på back-knappen så tas man tillbaka till föregående fönster som är MainWindow.
            MainWindow.Show();
            this.Close();
        }

        private void BackButton(object sender, RoutedEventArgs e) // Knappens funktion
        {
            var BackToMain = new MainWindow(); // Vid backbutton-klick på knappen så tas man tillbakatill Main-fönstret. 
            BackToMain.Show();
            this.Close();
        }

        private void SearchMovieField_TextChanged(object sender, TextChangedEventArgs e) // Knappens funktion
        {

        }
    }
}