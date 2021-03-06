namespace BookCave.Data.EntityModels
{
  public class Book
  {
    public int Id {get; set; }
    public string Title {get; set; }
    public string Genre {get; set; }
    public int ReleseYear {get; set; }
    public int AuthorId {get; set; }
    public double Rating {get; set; }
    public string Photo {get; set; }
    public double Price { get; set; }
    public string details { get; set; }

  }
}