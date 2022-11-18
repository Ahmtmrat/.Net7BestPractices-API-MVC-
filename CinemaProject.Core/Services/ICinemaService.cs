using CinemaProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Core.Services
{
    public interface ICinemaService:IGenericService<Cinema>
    {
        public Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>>GetCinemaWithMovieTheater();
        public Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>>GetCinemaByYearRange(int firstYear, int secondYear);
        public Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>>GetCinemaByDirectorWithYearRange(string director, int firstYear, int secondYear);
        public Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>>GetCinemaByGenreWithYearRange(string genre, int firstYear, int secondYear);
        public Task<CustomResponseDto<List<CinemaWithMovieTheaterDto>>> GetCinemaWithMovieTheaterWhere(Expression<Func<Cinema, bool>> expression);
    }
}
