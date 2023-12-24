﻿using eTeskra.Data;
using eTeskra.Data.Services;
using eTeskra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTeskra.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAll();
			return View(data);
		}

        //Get: Actors/Create
        public IActionResult Create()
        {           
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);
			}

			_service.Add(actor);
			return RedirectToAction(nameof(Index));
		}

	}
}
