using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models;

namespace BookCave.Data.EntityModels
{
    public class Orders 
    {   public int id {get; set; }
        public string UserId {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
        public List<Cart> Carts { get; set; }
    }
}