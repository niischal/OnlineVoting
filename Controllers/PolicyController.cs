

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService _service;
        public PolicyController(IPolicyService service)
        {
            _service = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Policy policies)
        {
            if (ModelState.IsValid)
            {
                return View(policies);
            }
            await _service.AddAsync(policies);
            return RedirectToAction("Index");
        }
    }
}
