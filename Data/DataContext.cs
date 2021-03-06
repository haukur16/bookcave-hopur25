using Microsoft.EntityFrameworkCore;
using BookCave.Data.EntityModels;
using Microsoft.Extensions.Configuration;
using System.IO;
using BookCave.Models;

namespace BookCave.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Author> Authors {get; set; }
    public DbSet<Book> Books {get; set; }
    public DbSet<UserLogin> UserLogins {get; set; }
    public DbSet<Billinginfo> BillingInfo {get; set; }
    public DbSet<BookReviews> BookReviews {get; set; }
    public DbSet<Orders> Orders {get; set; }
    public DbSet<Cart> Carts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.Json");
      var configuration = builder.Build();
      optionsBuilder
      .UseSqlServer(
        "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H25;Persist Security Info=False;User ID=VLN2_2018_H25_usr;Password=r!chCard14;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
  }
}