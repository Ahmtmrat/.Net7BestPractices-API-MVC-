using AutoMapper;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using CinemaProject.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Web.Controllers
{
    public class FiltreController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMovieTheaterService _movieTheaterService;
        private readonly IMapper _mapper;
        public FiltreController(ICinemaService cinemaService, IMovieTheaterService movieTheaterService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _movieTheaterService = movieTheaterService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> FilterGenreWithYears(string genre,int firstYear,int secondYear)
        {
            var filterCinema = await _cinemaService.GetCinemaByGenreWithYearRange(genre,firstYear,secondYear);           
            return View(filterCinema.Data);
        }
        public async Task<IActionResult> FilterDirectorWithYears(string director, int firstYear, int secondYear)
        {
            var filterCinema = await _cinemaService.GetCinemaByDirectorWithYearRange(director, firstYear, secondYear);
            return View(filterCinema.Data);
        }
        public async Task<IActionResult> FilterYearRange(int firstYear, int secondYear)
        {
            var filterCinema = await _cinemaService.GetCinemaByYearRange(firstYear, secondYear);
            return View(filterCinema.Data);
        }
        [ServiceFilter(typeof(NotFoundGenreFilter))]
        public async Task<IActionResult> FilterGenre(string genre)
        {
            var filterCinema = await _cinemaService.GetCinemaWithMovieTheaterWhere(x=>x.Genre==genre);          
            return View( filterCinema.Data);
        }
        [ServiceFilter(typeof(NotFoundDirectorFilter))]
        public async Task<IActionResult> FilterDirector(string director)
        {
            var filterCinema = await _cinemaService.GetCinemaWithMovieTheaterWhere(x => x.Director == director);
            return View(filterCinema.Data);
        }
        [ServiceFilter(typeof(NotFoundYearFilter))]
        public async Task<IActionResult> FilterYear(int year)
        {
            var filterCinema = await _cinemaService.GetCinemaWithMovieTheaterWhere(x => x.Year == year);
            return View(filterCinema.Data);
        }
    }
}
