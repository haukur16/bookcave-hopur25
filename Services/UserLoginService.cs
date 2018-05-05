using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
  public class UserLoginService
  {
    private UserLoginRepo _userLoginRepo;

    public UserLoginService()
    {
      _userLoginRepo = new UserLoginRepo();
    }
    public List<UserLoginListViewModel> GetAllUserLogin()
    {
      var userLogins = _userLoginRepo.GetAllUserLogin();

      return userLogins;
    }
  }
}