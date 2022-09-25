using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Data;
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
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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

            var newUser = new ApplicationUser()
            {
                FirstName = accountDetails.FirstName,
                LastName = accountDetails.LastName,
                Email = accountDetails.EmailAddress,
                UserName = accountDetails.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, accountDetails.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.Voter);
            }
            return RedirectToAction("Index", "Election");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Election");

        }
    }
}
