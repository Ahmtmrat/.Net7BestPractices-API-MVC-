using CinemaProject.Core;
using CinemaProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Repositories
{
    public class MovieTheaterRepository : GenericRepository<MovieTheater>, IMovieTheaterRepository
    {
        public MovieTheaterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
