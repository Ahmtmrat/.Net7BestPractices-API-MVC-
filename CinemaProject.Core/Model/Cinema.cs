using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Core.Model
{
    public class Cinema:BaseEntity
    {
        public string Genre { get; set; }
        public string Director { get; set; }
        [Range(1900, 2100)]
        public int Year { get; set; }
        public ICollection<MovieTheater> MovieTheaters { get; set; }

    }
}
