using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class ElectionService : EntityBaseRepository<Election>, IElectionService
    {
        private readonly AppDbContext _context;
        public ElectionService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<int?> GetByUserIdAsync(string userId)
        {
            var electionIds = _context.UserElections.Where(u => u.UserId == userId).Select(x=>x.ElectionId).ToList();
            return electionIds;
        }

        public List<Election> GetElectionsByElectionId(List<int?> electionIds)
        {
            List<Election> elections = new List<Election>();
            if (electionIds != null)
            {  
                foreach (var election in electionIds)
                {
                    if(election != null)
                    {
                        Election? e = new Election();
                        e = _context.Elections.Where(e => e.Id == election.Value).FirstOrDefault();
                        if (e != null)
                        {
                            elections.Add(e);
                        }
                    }
                    
                }
            }
            
            return elections; 
        }

        public async Task AddUserElection(int electionId,string userId)
        {
            UserElection ue = new UserElection()
            {
                UserId = userId,
                ElectionId = electionId
            };
            await _context.UserElections.AddAsync(ue);
            await _context.SaveChangesAsync();
        }
    }
}
