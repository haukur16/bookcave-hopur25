using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
  public class BookRepo
  {
    private DataContext _db;

    public BookRepo()
    {
      _db = new DataContext();
    }
    public List<BookListViewModel> GetAllBooks()
    {
      var books = (from a in _db.Books
                  join b in _db.Authors on a.AuthorId equals b.Id
                  select new BookListViewModel
                  {
                    BookId = a.Id,
                    Title = a.Title,
                    Genre = a.Genre,
                    ReleseYear = a.ReleseYear,
                    Author = b.Name,
                    AuthorId = b.Id,
                    Rating = a.Rating,
                    Photo = a.Photo,
                    Price = a.Price,
                    details = a.details
                  }).ToList();
      return books;
    }

    public List<BookListViewModel> GetBookById(int? Id)
    {
      var hasreview = from r in _db.BookReviews
                      where r.BookId == Id
                      select r;

      if(hasreview.Any())
      {
	      var books = (from a in _db.Books
				join b in _db.Authors on a.AuthorId equals b.Id
        join r in _db.BookReviews on a.Id equals r.BookId
				where a.Id == Id
				select new BookListViewModel
				{
					          BookId = a.Id,
                    Title = a.Title,
                    Genre = a.Genre,
                    ReleseYear = a.ReleseYear,
                    Author = b.Name,
                    AuthorId = b.Id,
                    Rating = a.Rating,
                    Photo = a.Photo,
                    Price = a.Price,
                    details = a.details,
                    UserId = r.UserId,
                    UserRating = r.UserRating,
                    BookReview = r.BookReview
				}).ToList();
        return books;
      }
      else 
      {
        var books = (from a in _db.Books
				join b in _db.Authors on a.AuthorId equals b.Id
				where a.Id == Id
				select new BookListViewModel
				{
					          BookId = a.Id,
                    Title = a.Title,
                    Genre = a.Genre,
                    ReleseYear = a.ReleseYear,
                    Author = b.Name,
                    AuthorId = b.Id,
                    Rating = a.Rating,
                    Photo = a.Photo,
                    Price = a.Price,
                    details = a.details,
				}).ToList();
        return books;
      }
    }
    
    public List<BookListViewModel> GetTopTenBooks(int Id)
    {
      var topbook = (from a in _db.Books
                  join b in _db.Authors on a.AuthorId equals b.Id
                  orderby a.Rating descending
                  select new BookListViewModel
                  {
                    BookId = a.Id,
                    Title = a.Title,
                    Genre = a.Genre,
                    ReleseYear = a.ReleseYear,
                    Author = b.Name,
                    AuthorId = b.Id,
                    Rating = a.Rating,
                    Photo = a.Photo,
                    Price = a.Price,
                    details = a.details
                    }).Take(10).ToList();
        return topbook;
    }

    public List<BookListViewModel> CatalogSearch(string titleSearch, string authorSearch, string filterGenre, double rating, string orderBy)
    {
      var catalogresults = (from a in _db.Books
                          join b in _db.Authors on a.AuthorId equals b.Id
                          select new BookListViewModel
                          {
                          BookId = a.Id,
                          Title = a.Title,
                          Genre = a.Genre,
                          ReleseYear = a.ReleseYear,
                          Author = b.Name,
                          AuthorId = b.Id,
                          Rating = a.Rating,
                          Photo = a.Photo,
                          Price = a.Price,
                          details = a.details
                          });
                          if (!string.IsNullOrEmpty(titleSearch))
                          {
                            catalogresults = catalogresults.Where(a => a.Title.Contains(titleSearch));
                          }
                          if (!string.IsNullOrEmpty(authorSearch))
                          {
                            catalogresults = catalogresults.Where(b => b.Author.Contains(authorSearch));
                          }
                          if (!string.IsNullOrEmpty(filterGenre))
                          {
                            catalogresults = catalogresults.Where(a => a.Genre.Contains(filterGenre));
                          }
                          if (rating != 0)
                          {
                            catalogresults = catalogresults.Where(a => a.Rating >= rating);
                          }
                          if (!string.IsNullOrEmpty(orderBy))
                          {
                            if (orderBy == "Rating")
                            {
                              catalogresults = catalogresults.OrderByDescending(a => a.Rating);
                            }
                            else if (orderBy == "Releaseyear")
                            {
                              catalogresults = catalogresults.OrderByDescending(a => a.ReleseYear);
                            }
                            else if (orderBy == "PriceH2L")
                            {
                              catalogresults = catalogresults.OrderByDescending(a => a.Price);
                            }
                            else if (orderBy == "PriceL2H")
                            {
                              catalogresults = catalogresults.OrderBy(a => a.Price);
                            }
                            else if (orderBy == "Alpha")
                            {
                              catalogresults = catalogresults.OrderBy(a => a.Title);
                            }
                          }
      return catalogresults.ToList();
    }

    public List<BookListViewModel> GetBookByLayoutSearch(string layoutsearch)
    {
      var layoutresults = (from a in _db.Books
                          join b in _db.Authors on a.AuthorId equals b.Id
                          select new BookListViewModel
                          {
                          BookId = a.Id,
                          Title = a.Title,
                          Genre = a.Genre,
                          ReleseYear = a.ReleseYear,
                          Author = b.Name,
                          AuthorId = b.Id,
                          Rating = a.Rating,
                          Photo = a.Photo,
                          Price = a.Price,
                          details = a.details
                          }
      );
      if (!string.IsNullOrEmpty(layoutsearch))
      {
        layoutresults = layoutresults.Where(a => a.Title.Contains(layoutsearch));
      }
      return layoutresults.ToList();
    }
  }
}