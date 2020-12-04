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

            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.RowDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.RowDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {

                        var movie = State.Movies[i];
                        try
                        {
                            var text = new Label() { };
                            text.Content = movie.Title;
                            text.HorizontalAlignment = HorizontalAlignment.Center;
                            text.VerticalAlignment = VerticalAlignment.Top;
                            text.FontSize = 16;
                            text.FontWeight = FontWeights.Bold;
                            text.FontFamily = new FontFamily("sans-serif");
                            text.Foreground = Brushes.Gray;

                            var image = new Image() { };
                            image.Cursor = Cursors.Hand;
                            image.MouseUp += Image_MouseUp;
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));
                            image.Height = 120;
                            image.Margin = new Thickness(4, 4, 4, 4);

                            var genre = new Label() { };
                            genre.Content = movie.Genre;
                            genre.HorizontalContentAlignment = HorizontalAlignment.Center;
                            genre.VerticalAlignment = VerticalAlignment.Bottom;
                            genre.Foreground = Brushes.MediumBlue;
                            genre.Margin = new Thickness(15);

                            MovieGrid.Children.Add(text);
                            Grid.SetRow(text, y); // Y-led för text.
                            Grid.SetColumn(text, x); // X-led för text.
                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y); // Y-led för bild.
                            Grid.SetColumn(image, x); // X-led för bild.
                            MovieGrid.Children.Add(genre);
                            Grid.SetRow(genre, y); // Y-led för genre.
                            Grid.SetColumn(genre, x); // X-led för genre.
                        }
                        catch (Exception exeption) when // Felhantering med catch.
                        (exeption is ArgumentException
                          || exeption is ArgumentNullException
                          || exeption is System.IO.FileNotFoundException
                          )
                        {
                            continue; // Fortsätt köra programmet även om fel uppstår.
                        }

                    }
                }
            }
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }
        // Kan söka på filmerna ifrån film-yoghurten.
        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                State.Movies.Clear();
                State.Movies.AddRange(API.GetMovieByName(TextBox.Text));
                var next_searchMovie = new SearchMovie();
                next_searchMovie.show();
                this.Close();

                if (State.Movies.Count == 0)
                {
                    MessageBox.Show("No movie found", "please try again!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Vad som händer när man klickar på en filmikon i appen. AK BJÖRN
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Ta reda på vilken kordinat den klickade bilden har.
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            //Används kordinaten för att ta reda på vilken motsvarande record det rör sig om.
            int i = y * MovieGrid.ColumnDefinitions.Count + x;
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
        private void SearchClick(object sender, RoutedEventArgs e)
        {

        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            var MainWindow = new LoginWindow();
            MainWindow.Show();
            this.Close();
        }

        private void SearchMovieField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {

        }
    }
}