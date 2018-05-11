using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
  public class OrderViewModel
  {
    public int Id { get; set; }
    public string UserId {get; set; }
    public int CartId {get; set; }
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