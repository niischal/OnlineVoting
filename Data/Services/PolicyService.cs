using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class PolicyService : EntityBaseRepository<Policy>, IPolicyService
    {
        private readonly AppDbContext _context;
        public PolicyService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
