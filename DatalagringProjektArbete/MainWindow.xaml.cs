using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int movie_skip_count = 0;
            int movie_take_count = 10; //Visar antalet filmer
            State.Movies = API.GetMovieSlice(movie_skip_count, movie_take_count);

            int column_count = MovieGrid.ColumnDefinitions.Count;
            int row_count = (int)Math.Ceiling((double)State.Movies.Count / (double)column_count);


            for (int y = 0; y < row_count; y++)
            { //Bestämmer hur hög raden skall vara i förhållande till applikationens fönster.
                MovieGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(140, GridUnitType.Pixel)
                });
                // Lägger till en film i varje cell för varje ny rad.
                for (int x = 0; x < column_count; x++)
                {
                    //Räknar ut vilken film som skall skrivas ut efter X och Y kordinater.
                    int i = y * column_count + x;
                    //Kollar så att vi inte försöker fylla mer Grid celler än vi har filmrecords.
                    if (i < State.Movies.Count)
                    {
                        //Hämtaett film record
                        var movie = State.Movies[i];

                        //Försök att skapa en imgae Controller(legobit) och
                        // Placera den i rätt Grid cell enl. x,y kordinaterna
                        //Skapa en image som visar filmomslaget
                        var image = new Image()
                        {
                            Cursor = Cursors.Hand, // Visar en "klicka hand" när man håller pekaren ovanför bilden.
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(4, 4, 4, 4),
                        };
                        image.MouseUp += Image_MouseUp;

                        try
                        {
                            image.Source = new BitmapImage(new Uri(movie.ImageURL)); // Hämtar bildlänken till ram
                        }
                        catch (Exception e) when
                        (e is ArgumentException || e is System.IO.FileNotFoundException || e is UriFormatException)
                        {
                            // Om något går fel så lägger vi in en placeholder.
                            image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image_placeholder.jpg"));
                        }

                        //Lägg till Image i Grid
                        MovieGrid.Children.Add(image);

                        //Placera in Image i Grid i kordinater X och Y
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                    }
                }
            }
        }
        // Vad som händer när man klickar på en filmikon i appen.
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Ta reda på vilken kordinat den klickade bilden har.
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            //Används kordinaten för att ta reda på vilken motsvarande record det rör sig om.
            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            //Lägg valet på minne.
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

        private void LoggOuteClick(object sender, RoutedEventArgs e)
        {
            var loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Close();
        }

        private void profileClick(object sender, RoutedEventArgs e)
        {

        }

        private void BrowsMovie(object sender, RoutedEventArgs e)
        {

        }
    }
}

