using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);

                ctx.AddRange(new List<Customer> {
                    new Customer { Name = "Alan Weik", Email = "AlanWeik@gmail.com" },
                    new Customer { Name = "Svante Pålsson", Email = "SvantePålsson@gmail.com" },
                    new Customer { Name = "Marcus Häst", Email = "Marcus@gmail.com" },
                    new Customer { Name = "Peter Svensson", Email = "PeterS@gmail.com" }, 
                    new Customer { Name = "Tony Makaroni", Email = "Tony@gmail.com" },
                    new Customer { Name = "Gustav Marklund", Email = "Gurra@gmail.com" },
                    new Customer { Name = "Mark Gustavsson", Email = "MarkG@gmail.com" },
                    new Customer { Name = "Lisa Field", Email = "LisaF@gmail.com" }, 
                    new Customer { Name = "Alma Svensson", Email = "Alma@gmail.com" },
                    new Customer { Name = "Fanny Wihlborg", Email = "Fanny@gmail.com" },
                    new Customer { Name = "Lina Lindberg", Email = "Lina@gmail.com" }, 
                    new Customer { Name = "Stina Elvland", Email = "Stina@hotmail.com" }, 
                    new Customer { Name = "Alice Eklund", Email = "Alice@hotmail.com" },
                    new Customer { Name = "Saga Eklund", Email = "Saga@hotmail.com" },

                });

                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 0; i < 200; i++)
                {
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                    try{ var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
