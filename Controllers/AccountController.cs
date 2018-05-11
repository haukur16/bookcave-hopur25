using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using authentication_repo.Models.ViewModels;
using BookCave.Data.EntityModels;
using BookCave.Helpers;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private OrderService _orderService;
        private List<Cart> _cart;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _orderService = new OrderService();
        } 

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) {return View();}
            var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, false);
                
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginListViewModel model)
        {
            if (!ModelState.IsValid) {return View();}
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return  RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ViewProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(new ProfileViewModel {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteBook = user.FavoriteBook,
                Age = user.Age,
                Avatar = user.Avatar,
                StreetName = user.StreetName,
                HouseNumber = user.HouseNumber,
                City = user.City,
                Country = user.Country,
                ZIP = user.ZIP
            });
        }
        

        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(new ProfileViewModel {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteBook = user.FavoriteBook,
                Age = user.Age,
                Avatar = user.Avatar,
                StreetName = user.StreetName,
                HouseNumber = user.HouseNumber,
                City = user.City,
                Country = user.Country,
                ZIP = user.ZIP
            });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            user.Avatar = model.Avatar;
            user.FavoriteBook = model.FavoriteBook;
            user.StreetName = model.StreetName;
            user.HouseNumber = model.HouseNumber;
            user.City = model.City;
            user.Country = model.Country;
            user.ZIP = model.ZIP;

            await _userManager.UpdateAsync(user);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _orderService.GetBooksInOrder();

            return View(new OrderViewModel {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StreetName = user.StreetName,
                HouseNumber = user.HouseNumber,
                City = user.City,
                Country = user.Country,
                ZIP = user.ZIP,
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            model.UserId = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.StreetName = user.StreetName;
            model.HouseNumber = user.HouseNumber;
            model.City = user.City;
            model.Country = user.Country;
            model.ZIP = user.ZIP;
            

            _orderService.CreateOrder(user, model);

            return View(model);
        }
    }
}