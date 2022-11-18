using CinemaProject.API.Filters;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using CinemaProject.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaWithDtoController : CustomBaseController
    {
        private readonly ICinemaServiceWithDto _cinemaService;
        public CinemaWithDtoController(ICinemaServiceWithDto service)
        {
            _cinemaService = service;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCinemaWithMovieTheater()
        {
            return CreateActionResult(await _cinemaService.GetCinemaWithMovieTheater());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            
            return CreateActionResult(await _cinemaService.GetAllAsync());
        }
        //[ServiceFilter(typeof(NotFoundFilter<Cinema>))] Filtre yaparken kullan
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            return CreateActionResult(await _cinemaService.GetByIdAsync(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CinemaCreateDto cinemaDto)
        {
           
            return CreateActionResult(await _cinemaService.AddAsync(cinemaDto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(CinemaUpdateDto cinemaDto)
        {
            
            return CreateActionResult(await _cinemaService.UpdateAsync(cinemaDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            
            return CreateActionResult(await _cinemaService.RemoveAsync(id));

        }

        [HttpGet("[action]/{director}/{firstyear}/{secondyear}")]
        public async Task<IActionResult> FilterOfDirectorWithYearRange(string director, int firstyear, int secondyear)
        {
            return CreateActionResult(await _cinemaService.GetCinemaByDirectorWithYearRange(director, firstyear, secondyear));
        }
        [HttpGet("[action]/{genre}/{firstyear}/{secondyear}")]
        public async Task<IActionResult> FilterOfGenreWithYearRange(string genre, int firstyear, int secondyear)
        {
            return CreateActionResult(await _cinemaService.GetCinemaByGenreWithYearRange(genre, firstyear, secondyear));
        }
        [HttpGet("[action]/{firstyear}/{secondyear}")]
        public async Task<IActionResult> FilterOfYearRange(int firstyear, int secondyear)
        {
            return CreateActionResult(await _cinemaService.GetCinemaByYearRange(firstyear, secondyear));
        }
        [ServiceFilter(typeof(NotFoundDirectorFilter))]
        [HttpGet("[action]/{director}")]
        public async Task<IActionResult> FilterOfDirector(string director)
        {
            return CreateActionResult(await _cinemaService.GetCinemaWithMovieTheaterWhere(x => x.Director == director));
        }
        [ServiceFilter(typeof(NotFoundGenreFilter))]
        [HttpGet("[action]/{genre}")]
        public async Task<IActionResult> FilterOfGenre(string genre)
        {
            return CreateActionResult(await _cinemaService.GetCinemaWithMovieTheaterWhere(x => x.Genre == genre));
        }
        [ServiceFilter(typeof(NotFoundYearFilter))]
        [HttpGet("[action]/{year}")]
        public async Task<IActionResult> FilterOfYear(int year)
        {
            return CreateActionResult(await _cinemaService.GetCinemaWithMovieTheaterWhere(x => x.Year == year));
        }
    }
}
