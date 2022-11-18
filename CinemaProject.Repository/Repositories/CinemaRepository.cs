using CinemaProject.Core;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Cinema>> GetCinemaByDirectorWithYearRange(string director, int firstYear, int secondYear)
        {
            return await _context.Cinemas.Where(c => c.Director == director && c.Year>=firstYear && c.Year<=secondYear).Include(x=>x.MovieTheaters).ToListAsync();
        }

        public async Task<List<Cinema>> GetCinemaByGenreWithYearRange(string genre, int firstYear, int secondYear)
        {
            return await _context.Cinemas.Where(c => c.Genre == genre && c.Year >= firstYear && c.Year <= secondYear).Include(x => x.MovieTheaters).ToListAsync();
        }

        public async Task<List<Cinema>> GetCinemaByYearRange(int firstYear, int secondYear)
        {
            return await _context.Cinemas.Include(x => x.MovieTheaters).Where(c => c.Year >= firstYear && c.Year <= secondYear).ToListAsync();
        }
        public async Task<List<Cinema>> GetCinemaWithMovieTheater()
        {
            return await _context.Cinemas.Include(x=>x.MovieTheaters).AsSingleQuery().ToListAsync();
        }
        public async Task<List<Cinema>> GetCinemaWithMovieTheaterWhere(Expression<Func<Cinema, bool>> expression)
        {
            return await _context.Cinemas.Where(expression).Include(x => x.MovieTheaters).ToListAsync();
        }
    }
}
