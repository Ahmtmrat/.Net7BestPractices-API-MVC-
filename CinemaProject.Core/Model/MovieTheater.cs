using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Core.Model
{
    public class MovieTheater:BaseEntity
    {
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        
    }
}
