using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Core.DTOs
{
    public class CinemaWithMovieTheaterDto:CinemaDto
    {
        public List<MovieTheaterDto> MovieTheaters { get; set; }
    }
}
