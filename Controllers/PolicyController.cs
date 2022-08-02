using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;

namespace OnlineVoting.Controllers
{
    public class PolicyController : Controller
    {
        private readonly AppDbContext _context;
        public PolicyController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var policies = await _context.Policies.ToListAsync();
            return View(policies);
        }
    }
}
