using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;

namespace OnlineVoting.Controllers
{
    public class CandidateController : Controller
    {
        private readonly AppDbContext _context;
        public CandidateController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var candidates=await _context.Candidates.ToListAsync();
            return View(candidates);
        }
    }
}
