using CinemaProject.Core.DTOs;
using System.Linq.Expressions;

namespace CinemaProject.Core.Repositories
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {
        Task<List<Cinema>> GetCinemaWithMovieTheater();
        Task<List<Cinema>> GetCinemaByYearRange(int firstYear, int secondYear);
        Task<List<Cinema>> GetCinemaByDirectorWithYearRange(string director, int firstYear, int secondYear);
        Task<List<Cinema>> GetCinemaByGenreWithYearRange(string genre, int firstYear, int secondYear);
        Task<List<Cinema>> GetCinemaWithMovieTheaterWhere(Expression<Func<Cinema, bool>> expression);
    }
}
