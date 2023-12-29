using eTeskra.Data;
using eTeskra.Data.Services;
using eTeskra.Data.Static;
using eTeskra.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTeskra.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
	public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;

        }

		[AllowAnonymous]
		public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

		//Get: Cinemas/Details/1
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
        {
            var cinemasDetails = await _service.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");

            return View(cinemasDetails);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var cinemasDetails = await _service.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");

            return View(cinemasDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemasDetails = await _service.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");
            return View(cinemasDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConf(int id)
        {
            var cinemasDetails = await _service.GetByIdAsync(id);
            if (cinemasDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}