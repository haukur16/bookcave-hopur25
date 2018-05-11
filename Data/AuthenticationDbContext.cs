using BookCave.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookCave.Models.ViewModels;
namespace BookCave.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<BookCave.Models.ViewModels.BookReviewModel> BookReviewModel { get; set; }
        public DbSet<BookCave.Models.ViewModels.OrderViewModel> OrderViewModel { get; set; }
    }
}