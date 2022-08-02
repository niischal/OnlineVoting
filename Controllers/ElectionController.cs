using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;

namespace OnlineVoting.Controllers
{
    public class ElectionController : Controller
    {
        private readonly AppDbContext _context;
        public ElectionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var elections = await _context.Elections.ToListAsync();
            return View(elections);
        }
    }
}
