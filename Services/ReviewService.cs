using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services 
{
    public class ReviewService
    {
        private ReviewsRepo _reviewsRepo;

        public ReviewService()
        {
        _reviewsRepo = new ReviewsRepo();
        }
        public List<BookReviewModel> GetReviewsForBook(int? Id)
        {
            var reviews = _reviewsRepo.GetReviewsForBook(Id);

            return reviews;
        }
    }
}