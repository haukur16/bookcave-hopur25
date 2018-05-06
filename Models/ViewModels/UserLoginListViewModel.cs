using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
  public class UserLoginListViewModel
  {
    public int UserId {get; set; }
    [EmailAddress]
    public string Email {get; set; }
    public string Password {get; set; }
    public bool RememberMe {get; set;}

  }
}