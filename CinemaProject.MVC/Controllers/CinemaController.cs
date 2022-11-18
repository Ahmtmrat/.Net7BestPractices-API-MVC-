using AutoMapper;
using CinemaProject.Core;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using CinemaProject.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMovieTheaterService _movieTheaterService;
        private readonly IMapper _mapper;
        public CinemaController(ICinemaService cinemaService, IMovieTheaterService movieTheaterService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _movieTheaterService = movieTheaterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetCinemaWithMovieTheater();
            return View(cinemas.Data);
        }
        public async Task<IActionResult> Create()
        {
            var movieTheaters = await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters.ToList());
            ViewBag.movieTheaters = new SelectList(movieTheatersDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CinemaDto cinemaDto)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(_mapper.Map<Cinema>(cinemaDto));
                
                return RedirectToAction(nameof(Index));
            }
            var movieTheaters = await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters.ToList());
            ViewBag.movieTheaters = new SelectList(movieTheatersDto, "Id", "Name");
            return View();

        }
        [ServiceFilter(typeof(NotFoundIdFilter<Cinema>))]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            
            var movieTheaters = await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters.ToList());
            ViewBag.movieTheaters = new SelectList(movieTheatersDto, "Id", "Name");
            return View(_mapper.Map<CinemaDto>(cinema));

        }
        [HttpPost]
        public async Task<IActionResult> Edit(CinemaDto cinemaDto)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.UpdateAsync(_mapper.Map<Cinema>(cinemaDto));
                return RedirectToAction(nameof(Index));
            }
            var movieTheaters = await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters.ToList());

            ViewBag.movieTheaters = new SelectList(movieTheatersDto, "Id", "Name");

            return View(cinemaDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            await _cinemaService.RemoveAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
