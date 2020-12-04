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
    /// Interaction logic for SearchMovie.xaml
    /// </summary>
    public partial class SearchMovie : Window
    {
        public SearchMovie()
        {
            InitializeComponent();
        }

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            State.Pick = API.SearchMovie(SearchMovieField.Text.Trim());
            if (State.Pick != null)
            {
                
            }
            else
            {
                MessageBox.Show("Failed, venture outdoors until fixed.");
            }

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            var BackToMain = new MainWindow();
            {
                BackToMain.Show();
                this.Close();
            }
        }

        private void SearchMovieField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}