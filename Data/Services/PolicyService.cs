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
        public string GetName(int eId)
        {
            var results = _context.Elections.Where(p => p.Id == eId).Select(e => e.ElectionName).FirstOrDefault();
            return results;
        }

        public async Task<IEnumerable<Policy>> GetPolicyAsync(int eId)
        {
            var results = await _context.Policies.Where(p => p.ElectionId == eId).ToListAsync();

            return results;
        }
       
        public async Task<Policy> UpdatePolicy(int eId, Policy policy)
        {
            Policy p = await _context.Policies.FindAsync(eId);
            p.PolicyTitle = policy.PolicyTitle;
            p.PolicyDescription = policy.PolicyDescription;
            _context.Attach(p);
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return p;
        }
    }
}
