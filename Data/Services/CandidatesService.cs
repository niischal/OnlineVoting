using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class CandidatesService : EntityBaseRepository<Candidate>, ICandidatesService
    {
        private readonly AppDbContext _context;
        public CandidatesService(AppDbContext context) : base(context)
        {             
            _context=context;
        }
       
        
    }
}
