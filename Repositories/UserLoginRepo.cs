using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
  public class UserLoginRepo
  {
    private DataContext _db;

    public UserLoginRepo()
    {
      _db = new DataContext();
    }
    public List<UserLoginListViewModel> GetAllUserLogin()
    {
      var userlogin = (from a in _db.UserLogins
                  select new UserLoginListViewModel
                  {
                    UserId = a.Id,
                    Email = a.Email,
                    Password = a.Password
                  }).ToList();
      return userlogin;
    }
  }
}