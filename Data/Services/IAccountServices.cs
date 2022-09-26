using OnlineVoting.Data.ViewModel;

namespace OnlineVoting.Data.Services
{
    public interface IAccountServices
    {
        Task Register(RegisterVM accountDetails);
        Task<bool> AutoLogin(RegisterVM accountDetails);
    }
}
