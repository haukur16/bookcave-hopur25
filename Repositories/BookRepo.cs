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