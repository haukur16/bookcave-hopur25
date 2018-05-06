using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int? Id)
        {
            //var books = _bookService.GetBookById(Id);
            //return View(books);

            if (Id == null)
            {
                return View("notfound");
            }

            var books = _bookService.GetBookById(Id);
            if(books == null)
            {
                return View("notfound");
            }
            return View(books);
        }

        public IActionResult TopTenBooks(int Id)
        {
            var books = _bookService.GetTopTenBooks(Id);
            return View(books);
        }



        
    }
}
