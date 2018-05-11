using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
  public class OrderRepo
  {
      private List<Cart> _cart;
      private DataContext _db;
    public OrderRepo()
    {
      _cart = new List<Cart>();
      _db = new DataContext();
    }

    public List<Book> GetBooksInOrder()
    {
      var orders = (from a in _cart
                  select new Book
                  {
                    Id = a.Book.Id
                  }).ToList();
      return orders;
    }

		internal void CreateOrder(ApplicationUser user, OrderViewModel model)
		{
			var order = new Orders
			{
        UserId = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        StreetName = user.StreetName,
        HouseNumber = user.HouseNumber,
        City = user.City,
        Country = user.Country,
        ZIP = user.ZIP,
        Carts = model.Carts
			};
			_db.Orders.Add(order);
			_db.SaveChanges();
		}
	}
}