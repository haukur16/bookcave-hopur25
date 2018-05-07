using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
  public class BookService
  {
    private BookRepo _bookRepo;

    public BookService()
    {
      _bookRepo = new BookRepo();
    }
    public List<BookListViewModel> GetAllBooks()
    {
      var books = _bookRepo.GetAllBooks();

      return books;
    }

    public List<BookListViewModel> GetBookById(int? Id)
    {
      var book = _bookRepo.GetBookById(Id);

      return book;
    }
    public List<BookListViewModel> GetTopTenBooks(int Id)
    {
      var book = _bookRepo.GetTopTenBooks(Id);

      return book;
    }

    public List<BookListViewModel> CatalogSearch(string titleSearch, string authorSearch, string filterGenre, double rating, string orderBy)
    {
        var book = _bookRepo.CatalogSearch(titleSearch, authorSearch, filterGenre, rating, orderBy);
        return book;
    }

    public List<BookListViewModel> GetBookByLayoutSearch(string layoutsearch)
    {
        var book = _bookRepo.GetBookByLayoutSearch(layoutsearch);
        return book;
    }
  }
}