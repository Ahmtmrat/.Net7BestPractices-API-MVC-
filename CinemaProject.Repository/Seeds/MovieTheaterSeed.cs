using CinemaProject.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Seeds
{
    public class MovieTheaterSeed : IEntityTypeConfiguration<MovieTheater>
    {
        public void Configure(EntityTypeBuilder<MovieTheater> builder)
        {
            builder.HasData(
                new MovieTheater
                {
                    Id=1,
                    Name="Cinemaximum",
                   CinemaId=12,
                },
                new MovieTheater
                {
                    Id = 2,
                    Name = "Meram",
                    CinemaId = 11,
                },
                new MovieTheater
                {
                    Id = 3,
                    Name = "Beyoğlu Yeşilçam",
                    CinemaId = 10,
                },
                new MovieTheater
                {
                    Id = 4,
                    Name = "Sancaktepe Çamsanpark",
                    CinemaId = 9,
                },
                new MovieTheater
                {
                    Id = 5,
                    Name = "Galeria Cine Matriks",
                    CinemaId = 8,
                },
                new MovieTheater
                {
                    Id = 6,
                    Name = "Ataköy Paribu Cineverse",
                    CinemaId = 7,
                },
                new MovieTheater
                {
                    Id = 7,
                    Name = "Avcılar Pelican Mall Cinema Pink",
                    CinemaId = 6,

                },
                new MovieTheater
                {
                    Id = 8,
                    Name = "Metroport Cine VIP",
                    CinemaId = 5,

                }, new MovieTheater
                {
                    Id = 9,
                    Name = "Bakırköy Carousel Cinema Pink",
                    CinemaId = 4,

                }, new MovieTheater
                {
                    Id = 10,
                    Name = "Halkalı 212 Cinemarine",
                    CinemaId = 3,
                }, new MovieTheater
                {
                    Id = 11,
                    Name = "Cinetech Mall Of İstanbul",
                    CinemaId = 2,
                },
                new MovieTheater
                {
                    Id = 12,
                    Name = "Beylikdüzü Perla Vista Cinema Pink",
                    CinemaId = 1,
                }
                );
        }
    }
}
