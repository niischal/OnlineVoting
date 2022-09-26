using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Data.Static;
using OnlineVoting.Data.ViewModel;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IAccountServices _services;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IAccountServices services)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            var response = new LogInVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM logInDetails)
        {
            if (!ModelState.IsValid) return View(logInDetails);

            var user = await _userManager.FindByEmailAsync(logInDetails.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, logInDetails.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, logInDetails.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Election");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please Try Again!";
                return View(logInDetails);
            }
            TempData["Error"] = "Wrong credentials. Please Try Again!";
            return View(logInDetails);

        }

        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }
        public IActionResult AdminRegister()
        {
            var response = new RegisterVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(RegisterVM accountDetails)
        {
            if (!ModelState.IsValid) return View(accountDetails);
            var user = await _userManager.FindByEmailAsync(accountDetails.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "You already have an account";
                return View(accountDetails);
            }

            var user2 = await _userManager.FindByNameAsync(accountDetails.UserName);
            if (user2 != null)
            {
                TempData["Error"] = "Username Taken";
                return View(accountDetails);
            }
            await _services.Register(accountDetails);
            bool var = await _services.AutoLogin(accountDetails);

            return RedirectToAction("Index", "Election");
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM accountDetails)
        {
            if (!ModelState.IsValid) return View(accountDetails);
            var user = await _userManager.FindByEmailAsync(accountDetails.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "You already have an account";
                return View(accountDetails);
            }

            var user2 = await _userManager.FindByNameAsync(accountDetails.UserName);
            if (user2 != null)
            {
                TempData["Error"] = "Username Taken";
                return View(accountDetails);
            }
            await _services.Register(accountDetails);
            bool var=await _services.AutoLogin(accountDetails);

            return RedirectToAction("Index", "Election");
        }

      

       

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");

        }
    }
}
