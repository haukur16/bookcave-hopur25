using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
  public class ReviewsRepo
  {
      private DataContext _db;
    public ReviewsRepo()
    {
      _db = new DataContext();
    }

    public List<BookReviewModel> GetReviewsForBook(int? Id)
    {
      var reviews = (from a in _db.Books
                  join b in _db.BookReviews on a.Id equals b.BookId
                  select new BookReviewModel
                  {
                    Id = b.Id,
                    UserId = b.UserId,
                    UserRating = b.UserRating,
                    BookReview = b.BookReview,
                  }).ToList();
      return reviews;
    }
  }
}