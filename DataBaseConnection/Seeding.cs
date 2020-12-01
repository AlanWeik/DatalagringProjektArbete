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
                    new Customer { Firstname = "Alan", Lastname = "Weik", Age = 12, Email = "AlanWeik@gmail.com" },
                    new Customer { Firstname = "Svante", Lastname = "Pålsson", Age = 66, Email = "SvantePålsson@gmail.com" },
                    new Customer { Firstname = "Marcus", Lastname = "Häst", Age = 45, Email = "Marcus@gmail.com" },
                    new Customer { Firstname = "Peter", Lastname = "Svensson", Age = 17, Email = "PeterS@gmail.com" },
                    new Customer { Firstname = "Tony", Lastname = "Makaroni", Age = 19, Email = "Tony@gmail.com" },
                    new Customer { Firstname = "Gustav", Lastname = "Marklund", Age = 20, Email = "Gurra@gmail.com" },
                    new Customer { Firstname = "Mark", Lastname = "Gustavsson", Age = 20, Email = "MarkG@gmail.com" },
                    new Customer { Firstname = "Lisa", Lastname = "Field", Age = 12, Email = "LisaF@gmail.com" },
                    new Customer { Firstname = "Alma", Lastname = "Svensson", Age = 45, Email = "Alma@gmail.com" },
                    new Customer { Firstname = "Fanny", Lastname = "Wihlborg", Age = 33, Email = "Fanny@gmail.com" },
                    new Customer { Firstname = "Lina", Lastname = "Lindberg", Age = 66, Email = "Lina@gmail.com" },
                    new Customer { Firstname = "Stina", Lastname = "Elvland", Age = 99, Email = "Stina@hotmail.com" },
                    new Customer { Firstname = "Alice", Lastname = "Eklund", Age = 32, Email = "Alice@hotmail.com" },
                    new Customer { Firstname = "Saga", Lastname = "Eklund", Age = 11, Email = "Saga@hotmail.com" },

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
