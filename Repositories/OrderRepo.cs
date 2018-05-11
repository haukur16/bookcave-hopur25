using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Helpers;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BookCave.Repositories
{
  public class OrderRepo
  {
      private DataContext _db;
    public OrderRepo()
    {
      _db = new DataContext();
    }

		public void CreateOrder(ApplicationUser user, OrderViewModel model, List<Cart> cart)
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
              ZIP = user.ZIP
            };
          _db.Orders.Add(order);
          _db.SaveChanges();
      foreach(var a in cart)
      {
        var car = new Cart
        {
          Book = a.Book,
          OrderId = a.OrderId,
          Quantity = a.Quantity,
          Order = a.Order
        };
        _db.Carts.Add(car);
        _db.SaveChanges();
      }
    }
	}
}