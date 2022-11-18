using AutoMapper;
using CinemaProject.Core;
using CinemaProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Cinema,CinemaDto>().ReverseMap();
            CreateMap<MovieTheater,MovieTheaterDto>().ReverseMap();
            CreateMap<Cinema, CinemaWithMovieTheaterDto>();
            CreateMap<Cinema, CinemaUpdateDto>().ReverseMap();
            CreateMap<CinemaCreateDto, Cinema>();
        }
    }
}
