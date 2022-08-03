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
            if (ModelState.IsValid)
            {
                return View(elections);
            }
            await _service.AddAsync(elections);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var elections = _service.GetByIdAsync(id);
            if (elections == null) return View("Empty");
            return View(elections);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,Election elections)
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
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var elections = _service.GetByIdAsync(id);
            if (elections == null) return View("Empty");
            return View(elections);
        }

     
    }
}
