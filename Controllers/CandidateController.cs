using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidatesService _service;
        public CandidateController(ICandidatesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int id)
        {
            var candidates=await _service.GetCandidatesAsync(id);
            return View(candidates);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CandidateIcon,CandidateName")]Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                return View(candidate);
            }
            await _service.AddAsync(candidate);
            return RedirectToAction("Index");
        }

        public  IActionResult Details(int id)
        {
            var candidate =  _service.GetByIdAsync(id);
            if (candidate == null) return View("Empty");
            return View(candidate);
        }

        
    }
}
