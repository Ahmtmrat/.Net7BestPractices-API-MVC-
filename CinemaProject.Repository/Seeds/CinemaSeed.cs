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
    public class CinemaSeed : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(
                new Cinema {
                    Id=1,
                    Name="Yüzüklerin Efendisi: Yüzük Kardeşliği",
                    Director= "Peter Jackson",
                    Genre="Epik Fantezi",
                    Year=2001,
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Yüzüklerin Efendisi: İki Kule",
                    Director = "Peter Jackson",
                    Genre = "Epik Fantezi",
                    Year = 2002,
                },
                new Cinema
                {
                    Id = 3,
                    Name = "Yüzüklerin Efendisi: Kralın Dönüşü",
                    Director = "Peter Jackson",
                    Genre = "Epik Fantezi",
                    Year = 2003,
                },
                new Cinema
                {
                    Id = 4,
                    Name = "Hobbit: Beklenmedik Yolculuk",
                    Director = "Peter Jackson",
                    Genre = "Epik Fantezi",
                    Year = 2012,
                },
                new Cinema
                {
                    Id = 5,
                    Name = "Hobbit: Smaug'un Çorak Toprakları",
                    Director = "Peter Jackson",
                    Genre = "Epik Fantezi",
                    Year = 2013,
                },
                new Cinema
                {
                    Id = 6,
                    Name = "Hobbit: Beş Ordunun Savaşı",
                    Director = "Peter Jackson",
                    Genre = "Epik Fantezi",
                    Year = 2014,
                },
                new Cinema
                {
                    Id = 7,
                    Name = "Karayip Korsanları: Siyah İnci'nin Laneti",
                    Director = "Gore Verbinski",
                    Genre = "Macera Aksiyon",
                    Year = 2003,
                },
                new Cinema
                {
                    Id = 8,
                    Name = "Karayip Korsanları: Ölü Adamın Sandığı",
                    Director = "Gore Verbinski",
                    Genre = "Macera Aksiyon",
                    Year = 2006,
                },
                new Cinema
                {
                    Id = 9,
                    Name = "Karayip Korsanları: Dünyanın Sonu",
                    Director = "Gore Verbinski",
                    Genre = "Macera Aksiyon",
                    Year = 2007,
                },
                new Cinema
                {
                    Id = 10,
                    Name = "Karayip Korsanları: Gizemli Denizlerde",
                    Director = "Robb Marshall",
                    Genre = "Macera Aksiyon",
                    Year = 2011,
                },
                new Cinema
                {
                    Id = 11,
                    Name = "Karayip Korsanları: Salazar'ın İntikamı",
                    Director = "Espen Sandberg",
                    Genre = "Macera Aksiyon",
                    Year = 2017,

                }, new Cinema
                {
                    Id = 12,
                    Name = "7. Koğuştaki Mucize",
                    Director = "Mehmet Ada Öztekin",
                    Genre = "Dram",
                    Year = 2019,
                }
                );
        }
    }
}
