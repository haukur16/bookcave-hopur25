using BookCave.Data.EntityModels;

namespace BookCave.Models.EntityModels
{
    public class Cart
    {
        public Book Book {get; set; }
        public int Quantity {get; set; }
    }
}