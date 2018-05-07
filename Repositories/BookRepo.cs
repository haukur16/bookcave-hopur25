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
                    Photo = a.Photo
                  }).ToList();
      return books;
    }

    public List<BookListViewModel> GetBookById(int? Id)
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
                    Photo = a.Photo
				}).ToList();
        return books;
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
                    Photo = a.Photo
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
                          Photo = a.Photo
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
                            else if (orderBy == "title")
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
                          Photo = a.Photo
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