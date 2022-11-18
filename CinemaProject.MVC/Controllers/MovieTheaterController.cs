using AutoMapper;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Web.Controllers
{
    public class MovieTheaterController : Controller
    {
        private readonly IMovieTheaterService _movieTheaterService;
        private readonly IMapper _mapper;
       
        public MovieTheaterController(IMovieTheaterService movieTheaterService, IMapper mapper)
        {
            _movieTheaterService = movieTheaterService;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> Index()
        {
            var movieTheaters = await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters.ToList());
            return View(movieTheatersDto);
        }
    }
}
