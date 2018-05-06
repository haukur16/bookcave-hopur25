using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
  public class BillingInfoService
  {
    private BillingInfoRepo _billingInfoRepo;

    public BillingInfoService()
    {
      _billingInfoRepo = new BillingInfoRepo();
    }
    public List<BillingInfoListViewModel> GetAllBillingInfo()
    {
      var billingInfo = _billingInfoRepo.GetAllBillingInfo();

      return billingInfo;
    }
  }
}