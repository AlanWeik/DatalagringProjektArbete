﻿using System;
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
                ctx.RemoveRange(ctx.Customers);
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);

                //Lista med kunder som vi lagt till.

                ctx.AddRange(new List<Customer> {
                    new Customer { Username = "Alanski", Firstname = "Alan", Lastname = "Weik", Age = 12, Email = "AlanWeik@gmail.com" },
                    new Customer { Username = "Svantski", Firstname = "Svante", Lastname = "Pålsson", Age = 66, Email = "SvantePålsson@gmail.com" },
                    new Customer { Username = "Marcsi", Firstname = "Marcus", Lastname = "Häst", Age = 45, Email = "Marcus@gmail.com" },
                    new Customer { Username = "Petrovski", Firstname = "Peter", Lastname = "Svensson", Age = 17, Email = "PeterS@gmail.com" },
                    new Customer { Username = "Tonski", Firstname = "Tony", Lastname = "Makaroni", Age = 19, Email = "Tony@gmail.com" },
                    new Customer { Username = "Gusti", Firstname = "Gustav", Lastname = "Marklund", Age = 20, Email = "Gurra@gmail.com" },
                    new Customer { Username = "Marksi", Firstname = "Mark", Lastname = "Gustavsson", Age = 20, Email = "MarkG@gmail.com" },
                    new Customer { Username = "Lisi", Firstname = "Lisa", Lastname = "Field", Age = 12, Email = "LisaF@gmail.com" },
                    new Customer { Username = "Alma", Firstname = "Alma", Lastname = "Svensson", Age = 45, Email = "Alma@gmail.com" },
                    new Customer { Username = "Fanski", Firstname = "Fanny", Lastname = "Wihlborg", Age = 33, Email = "Fanny@gmail.com" },
                    new Customer { Username = "Linski", Firstname = "Lina", Lastname = "Lindberg", Age = 66, Email = "Lina@gmail.com" },
                    new Customer { Username = "Stinski", Firstname = "Stina", Lastname = "Elvland", Age = 99, Email = "Stina@hotmail.com" },
                    new Customer { Username = "Alice", Firstname = "Alice", Lastname = "Eklund", Age = 32, Email = "Alice@hotmail.com" },
                    new Customer { Username = "Saga", Firstname = "Saga", Lastname = "Eklund", Age = 11, Email = "Saga@hotmail.com" },
                    new Customer {Username = "Admin", Firstname = "Admin" },

                });

                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 0; i < 200; i++)
                {
                    var cells = lines[i].Split(','); // Splittar en stäng och sperarerar celler.

                    var url = cells[5].Trim('"');

                    try{ var test = new Uri(url); } // Testar att initiera en ny instans av URI klassen.
                    catch (Exception) { continue; } // Fångar vid fel.

                    movies.Add(new Movie { Title = cells[2], ImageURL = url }); // Skriver ut bilder på filmer på skrämen. 
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
