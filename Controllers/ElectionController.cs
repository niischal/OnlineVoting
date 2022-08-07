using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class ElectionController : Controller
    {
        private readonly IElectionService _service;
        public ElectionController(IElectionService service)
        {
            _service = service;
        }



        public async Task<IActionResult> Index()
        {
            var elections = await _service.GetAllAsync();
            return View(elections);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Election elections)
        {
            if (!ModelState.IsValid)
            {
                return View(elections);
            }
            await _service.AddAsync(elections);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Election elections)
        {
            if (ModelState.IsValid)
            {
                return View(elections);
            }
            await _service.UpdateAsync(id,elections);
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> Remove(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }
        [HttpPost,ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }

     
    }
}
