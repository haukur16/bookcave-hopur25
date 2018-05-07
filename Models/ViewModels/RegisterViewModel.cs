using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
  public class RegisterViewModel
  {
    public int UserId {get; set; }
    [Required]
    [EmailAddress]
    public string Email {get; set; }
    [Required]
    public string FirstName {get; set; }
    [Required]
    public string LastName {get; set; }
    [Required]
    public string Password {get; set; }

  }
}