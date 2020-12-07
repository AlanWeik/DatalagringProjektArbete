using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class Customer  //Här inne skapar vi tables med vad dom ska ha hålla för värden. 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public virtual List<Rental> Sales { get; set; }

    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Rental> Sales { get; set; }
    }
    public class Rental
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
