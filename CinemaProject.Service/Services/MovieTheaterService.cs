using AutoMapper;
using CinemaProject.Core;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Repositories;
using CinemaProject.Core.Services;
using CinemaProject.Core.UnitOfWorks;
using CinemaProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Service.Services
{
    public class MovieTheaterService : GenericService<MovieTheater>, IMovieTheaterService
    {
        private readonly IMovieTheaterRepository _repository;
        private readonly IMapper _mapper;
        public MovieTheaterService(IGenericRepository<MovieTheater> repository, IUnitOfWork unitOfWork, IMovieTheaterRepository movieRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = movieRepository;
            _mapper = mapper;
        }

       
    }
}
