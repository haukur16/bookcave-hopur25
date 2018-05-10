using BookCave.Data.EntityModels;

namespace BookCave.Models
{
    public class Cart
    {
        public string CartId {get; set; }
        public Book Book {get; set; }
        public int Quantity {get; set; }
    }
}