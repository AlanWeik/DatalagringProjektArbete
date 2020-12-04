using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public static class API
    {
        public static Context ctx; // Public så att vi kan koppla API till dess fönster vi skapar.

        static API() // Här inne skriver vi våra queries och bestämmer lite vad som ska visas och hända ifrån SQL-servern genom datorbasen i våra tables.
        {
            ctx = new Context();
        }
        public static List<Movie>GetMovieSlice(int skip_x, int take_x) // Lista för movie. 
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Skip(skip_x)
                .Take(take_x)
                .ToList(); 
        }
        public static Customer GetCustomerByName(string name)
        {
            return ctx.Customers
                .FirstOrDefault(c => c.Username.ToLower() == name.ToLower());
            // Snacka om att använda username istället för Fname och Lname. 
        }

        public static Movie SearchMovie(string Title)
        {
            return ctx.Movies
               .FirstOrDefault(c => c.Title.ToLower() == Title.ToLower()); // Lambda-uttryck för bokstavskombination så att programmet inte krashar vid inlogg.
        }
        public static bool RegisterSale(Customer customer, Movie movie) // Sale för rental. 
        {
            try
            {
                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie }); // Adderar ett nytt köp/hyrd film
                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added; // Returnerar köpet.
            }
            catch(DbUpdateException e) // Vid fel..
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
        public static List<Movie> GetMovieByName(string title)
        {
            return ctx.Movies.AsEnumerable().Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList(); // Någon lambda som jag aldrig lär mig hur fan det ens funkar? Men jämför med angiven textsträng med det som finns i Movie-listan.
        }
    }
}