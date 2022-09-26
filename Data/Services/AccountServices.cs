using Microsoft.AspNetCore.Identity;
using OnlineVoting.Data.ViewModel;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IdentityResult> Register (RegisterVM accountDetails)
        {
            var newUser = new ApplicationUser()
            {
                FirstName = accountDetails.FirstName,
                LastName = accountDetails.LastName,
                Email = accountDetails.EmailAddress,
                UserName = accountDetails.UserName
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, accountDetails.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, accountDetails.Role);
            }
            return newUserResponse;
        }

        public async Task<bool> AutoLogin (RegisterVM accountDetails)
        {

            var user = await _userManager.FindByEmailAsync(accountDetails.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, accountDetails.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, accountDetails.Password, false, false);
                    if (!result.Succeeded)
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }
    }
}
