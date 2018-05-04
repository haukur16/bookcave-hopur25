using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
           var db = new DataContext();
            
                var initialBooks = new List<Book>()
                    {
                        new Book {Title = "Harry Potter and the Philosopher's Stone", Genre = "Fantasy", ReleseYear = 2015, AuthorId = 1},
                        new Book {Title = "Fantastic Beasts and Where to Find Them : The Original Screenplay", Genre = "Fantasy", ReleseYear = 2016, AuthorId = 1},
                        new Book {Title = "Harry Potter and the Prisoner of Azkaban : Illustrated Edition", Genre = "Fantasy", ReleseYear = 2017, AuthorId = 1}
                    };
                    db.AddRange(initialBooks);
                    db.SaveChanges();
        }
    }
}