namespace BookCave.Data.EntityModels
{
    public class BookReviews 
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string BookReview { get; set; }
        public int UserRating { get; set; }
    }
}