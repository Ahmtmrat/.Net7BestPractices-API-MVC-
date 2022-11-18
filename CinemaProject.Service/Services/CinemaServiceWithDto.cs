using AutoMapper;
using CinemaProject.Core;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Repositories;
using CinemaProject.Core.Services;
using CinemaProject.Core.UnitOfWorks;
using CinemaProject.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Service.Services
{
    public class CinemaServiceWithDto : ServiceWithDto<Cinema, CinemaDto>, ICinemaServiceWithDto
    {
        private readonly ICinemaRepository _cinemaRepository;
     

        public CinemaServiceWithDto(ICinemaRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
           _cinemaRepository= repository;
        }

        public async Task<CustomResponseDto<CinemaDto>> AddAsync(CinemaCreateDto cinemaCreateDto)
        {
            var  newEntity = _mapper.Map<Cinema>(cinemaCreateDto);
            await _cinemaRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<CinemaDto>(newEntity);
            return CustomResponseDto<CinemaDto>.Success(StatusCodes.Status200OK, newDto);

        }

        public async Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaByDirectorWithYearRange(string director, int firstYear, int secondYear)
        {
            var cinemas = await _cinemaRepository.GetCinemaByDirectorWithYearRange(director, firstYear, secondYear);
            var cinemaDto = _mapper.Map<List<CinemaWithMovieTheaterDto>>(cinemas);
            if (cinemas.Count == 0)
            {
                throw new ClientSideException($"This {director} has no films between {firstYear}-{secondYear}!");
            }
            //return cinemaDto; For Single MVC
            return CustomResponseDto<List<CinemaWithMovieTheaterDto>>.Success(200, cinemaDto);
        }

        public async Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaByGenreWithYearRange(string genre, int firstYear, int secondYear)
        {
            var cinemas = await _cinemaRepository.GetCinemaByGenreWithYearRange(genre, firstYear, secondYear);
            var cinemaDto = _mapper.Map<List<CinemaWithMovieTheaterDto>>(cinemas);
            if (cinemas.Count == 0)
            {
                throw new ClientSideException($"This {genre} has no films between {firstYear}-{secondYear}!");
            }
            //return cinemaDto;
            return CustomResponseDto<List<CinemaWithMovieTheaterDto>>.Success(200, cinemaDto);
        }

        public async Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaByYearRange(int firstYear, int secondYear)
        {
            var cinemas = await _cinemaRepository.GetCinemaByYearRange(firstYear, secondYear);
            var cinemaDto = _mapper.Map<List<CinemaWithMovieTheaterDto>>(cinemas);
            if (cinemas.Count == 0)
            {
                throw new ClientSideException($"This has no films between {firstYear}-{secondYear}!");
            }
            //return cinemaDto;
            return CustomResponseDto<List<CinemaWithMovieTheaterDto>>.Success(200, cinemaDto);
        }

        public async Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaWithMovieTheater()
        {
            var cinemas = await _cinemaRepository.GetCinemaWithMovieTheater();
            var cinemaDto = _mapper.Map<List<CinemaWithMovieTheaterDto>>(cinemas);
            //return cinemaDto;
            return CustomResponseDto<List<CinemaWithMovieTheaterDto>>.Success(200, cinemaDto);
        }

        public async Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaWithMovieTheaterWhere(Expression<Func<Cinema, bool>> expression)
        {
            var cinemas = await _cinemaRepository.GetCinemaWithMovieTheaterWhere(expression);
            var cinemaDto = _mapper.Map<List<CinemaWithMovieTheaterDto>>(cinemas);
            //return cinemaDto;
            return CustomResponseDto<List<CinemaWithMovieTheaterDto>>.Success(200, cinemaDto);
        }
        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(CinemaUpdateDto cinemaUpdateDto)
        {
            var entity = _mapper.Map<Cinema>(cinemaUpdateDto);
            _cinemaRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);

        }
    }
}
