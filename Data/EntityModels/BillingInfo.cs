namespace BookCave.Data.EntityModels
{
  public class Billinginfo
  {
    public int Id {get; set; }
    public int UserLoginId {get; set; }
    public string StreetName {get; set; }
    public int HouseNumber {get; set; }
    public string City {get; set; }
    public string Country {get; set; }
    public int ZipCode {get; set; }
  }
}