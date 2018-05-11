using System;
using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services 
{
    public class OrderService
    {
        private OrderRepo _orderRepo;

        public OrderService()
        {
        _orderRepo = new OrderRepo();
        }

        public void CreateOrder(ApplicationUser user, OrderViewModel model, List<Cart> cart)
        {
        _orderRepo.CreateOrder(user, model, cart);
        }
}
}