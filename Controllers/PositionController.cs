using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _service;
        public PositionController(IPositionService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index(int Id)
        {
            var positions = await _service.GetPositionAsync(Id);
            ViewBag.EId = Id;
            return View(positions);
        }


        public IActionResult Create(int id)
        {
            var name = _service.GetName(id);
            ViewBag.EId = id;
            ViewBag.Name = name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PositionTitle,Description,ElectionId")] Position position)
        
        {
            if (ModelState.IsValid)
            { 
                return View(position);
            }
            await _service.AddAsync(position);
            return Redirect("../Index/"+position.ElectionId);
        }

        public async Task<IActionResult> Update(int id)
        {
            var position = await _service.GetByIdAsync(id);
            if (position == null) return View("NotFound");
            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("PositionTitle,Description.")] Position position)
        {

            if (ModelState.IsValid)
            {
                return View(position);
            }

            ViewBag.EId = position.ElectionId;
            await _service.UpdatePosition(id, position);

            return Redirect("../Index/" + id);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var Position = await _service.GetByIdAsync(id);
            if (Position == null) return View("NotFound");
            return View(Position);
        }
        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var position = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(id);
            
            return Redirect("../Index/"+position.ElectionId);
            //return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var Position = await _service.GetByIdAsync(id);
            if (Position == null) return View("NotFound");
            return View(Position);
        }

    }
}
