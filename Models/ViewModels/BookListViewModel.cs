namespace BookCave.Models.ViewModels
{
  public class BookListViewModel
  {
    public int BookId {get; set; }
    public string Title {get; set; }
    public string Genre {get; set; }
    public int ReleseYear {get; set; }
    public string Author {get; set; }
    public int AuthorId {get; set; }
    public double Rating {get; set; }
    public string Photo {get; set; }
    public double Price { get; set; }
    public string details { get; set; }
    public int UserRating { get; set; }
    public string UserId { get; set; }
    public string BookReview { get; set; }
    public string UserName { get; set; }
  }
}