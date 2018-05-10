namespace authentication_repo.Models.ViewModels
{
  public class ProfileViewModel
  {
    public string FirstName {get; set; }
    public string LastName {get; set; }
    public int Avatar { get; set; }
    public string FavoriteBook {get; set; }
    public int Age {get; set; }
    public string StreetName { get; set; }
    public int HouseNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZIP { get; set; }
  }
}