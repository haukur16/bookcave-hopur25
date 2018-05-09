using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class BookReviewModel 
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        [EmailAddress]
        public string BookReview { get; set; }
        public int UserRating { get; set; }
    }
}