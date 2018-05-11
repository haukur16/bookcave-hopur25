using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models
{
    public class Cart
    {
        public int id {get; set; }
        public Book Book {get; set; }
        public int Quantity {get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
  }
}