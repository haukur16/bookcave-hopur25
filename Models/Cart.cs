using BookCave.Data.EntityModels;

namespace BookCave.Models
{
    public class Cart
    {
        public Book Book {get; set; }
        public int Quantity {get; set; }
    }
}