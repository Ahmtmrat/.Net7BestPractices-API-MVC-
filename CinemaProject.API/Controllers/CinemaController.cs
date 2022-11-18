using AutoMapper;
using CinemaProject.Core.DTOs;
using CinemaProject.Core;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using CinemaProject.API.Filters;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CinemaProject.API.Controllers
{

    public class CinemaController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICinemaService _cinemaService;
        public CinemaController(IMapper mapper, ICinemaService cinemaService)
        {
            _mapper = mapper;
            _cinemaService = cinemaService;

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCinemaWithMovieTheater()
        {
            return CreateActionResult(await _cinemaService.GetCinemaWithMovieTheater());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            var cinemasDto = _mapper.Map<List<CinemaDto>>(cinemas.ToList());
            return CreateActionResult(CustomResponseDto<List<CinemaDto>>.Success(200, cinemasDto));
        }
        //[ServiceFilter(typeof(NotFoundFilter<Cinema>))] Filtre yaparken kullan
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            var cinemasDto = _mapper.Map<CinemaDto>(cinema);
            return CreateActionResult(CustomResponseDto<CinemaDto>.Success(200, cinemasDto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CinemaDto cinemaDto)
        {
            var cinema = await _cinemaService.AddAsync(_mapper.Map<Cinema>(cinemaDto));
            var cinemasDto = _mapper.Map<CinemaDto>(cinema);
            return CreateActionResult(CustomResponseDto<CinemaDto>.Success(201, cinemasDto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(CinemaDto cinemaDto)
        {
            await _cinemaService.UpdateAsync(_mapper.Map<Cinema>(cinemaDto));
            return CreateActionResult(CustomResponseDto<CinemaDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            await _cinemaService.RemoveAsync(cinema);
            return CreateActionResult(CustomResponseDto<CinemaDto>.Success(204));

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
