using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
  public class BillingInfoRepo
  {
    private DataContext _db;

    public BillingInfoRepo()
    {
      _db = new DataContext();
    }
    public List<BillingInfoListViewModel> GetAllBillingInfo()
    {
      var billingInfo = (from a in _db.BillingInfo
                        join b in _db.UserLogins on a.UserLoginId equals b.Id
                  select new BillingInfoListViewModel
                  {
                    Id = a.Id,

                    StreetName = a.StreetName,
                    HouseNumber = a.HouseNumber,
                    City = a.City,
                    Country = a.Country,
                    ZipCode = a.ZipCode
                  }).ToList();
      return billingInfo;
  }
}
}