using AutoMapper;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.API.Controllers
{
    public class MovieTheaterController : CustomBaseController
    {
        private readonly IMovieTheaterService _movieTheaterService;
        private readonly IMapper _mapper;
        public MovieTheaterController(IMovieTheaterService movieTheaterService,IMapper mapper)
        {
            _movieTheaterService = movieTheaterService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movieTheaters =await _movieTheaterService.GetAllAsync();
            var movieTheatersDto = _mapper.Map<List<MovieTheaterDto>>(movieTheaters);
            return CreateActionResult(CustomResponseDto<List<MovieTheaterDto>>.Success(200,movieTheatersDto));
        }
    }
}
