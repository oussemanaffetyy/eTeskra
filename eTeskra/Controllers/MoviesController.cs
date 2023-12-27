using eTeskra.Data;
using eTeskra.Data.Services;
using eTeskra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTeskra.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Cinema);
            return View(data);
        }
            //Get: Movies/Details/1
            public async Task<IActionResult> Details(int id)
            {
                var moviesDetails = await _service.GetMovieByIdAsync(id);
                

                return View(moviesDetails);
            }
        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name"); 
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName"); 
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid) 
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var moviesDetails = await _service.GetMovieByIdAsync(id);
            if(moviesDetails == null)
            {
                return View("NotFound");

            }
            var respone = new NewMovieVM()
            {
                Id = moviesDetails.Id,
                Name = moviesDetails.Name,
                Description = moviesDetails.Description,
                Price = moviesDetails.Price,
                MovieCategory = moviesDetails.MovieCategory,
                ImageUrl = moviesDetails.ImageUrl,
                StartDate = moviesDetails.StartDate,
                EndDate = moviesDetails.EndDate,
                CinemaId = moviesDetails.CinemaId,
                ProducerId = moviesDetails.ProducerId,
                ActorIds = moviesDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
           
                var movieDropdownsData = await _service.GetMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(respone);
           
             
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        
         public async Task<IActionResult> Filter(string searchString)
          {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allMovies.Where(n => n.Name.Contains(searchString) ||
                n.Description.Contains(searchString)).ToList();
                return View("Index",filterResult);
            }
                    return View("Index", allMovies);
           }
    }


}