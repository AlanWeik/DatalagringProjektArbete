﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class Customer
    {
        public int Id { get; set; } //PK
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public virtual List<Rental> Sales { get; set; } //FK

    }
    public class Movie
    {
        public int Id { get; set; } //PK
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Rental> Sales { get; set; } //FK
    }
    public class Rental
    {
        public int Id { get; set; } //PK
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; } //FK
        public virtual Movie Movie { get; set; } //FK
    }
}
