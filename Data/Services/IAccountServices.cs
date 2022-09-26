using Microsoft.AspNetCore.Identity;
using OnlineVoting.Data.ViewModel;

namespace OnlineVoting.Data.Services
{
    public interface IAccountServices
    {
        Task<IdentityResult> Register(RegisterVM accountDetails);
        Task<bool> AutoLogin(RegisterVM accountDetails);
    }
}
