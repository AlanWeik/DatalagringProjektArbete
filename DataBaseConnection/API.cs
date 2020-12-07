using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public static class API
    {
        public static Context ctx; // Public så att vi får tillgång till API:ER i dom andra kodfönsterna.

        static API() // Här inne skriver vi våra queries och bestämmer lite vad som ska visas och hända ifrån SQL-servern genom datorbasen i våra tables.
        {
            ctx = new Context();
        }
        public static List<Movie>GetMovieSlice(int skip_x, int take_x) 
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
        }

        public static Movie SearchMovie(string Title)
        {
            return ctx.Movies
               .FirstOrDefault(c => c.Title.ToLower() == Title.ToLower());
        }
        public static bool RegisterSale(Customer customer, Movie movie) 
        {
            try
            {
                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });
                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch(DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
        public static List<Movie> GetMovieByName(string title)
        {
            return ctx.Movies.AsEnumerable().Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}