using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaProject.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTheaters_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Director", "Genre", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Peter Jackson", "Epik Fantezi", "Yüzüklerin Efendisi: Yüzük Kardeşliği", 2001 },
                    { 2, "Peter Jackson", "Epik Fantezi", "Yüzüklerin Efendisi: İki Kule", 2002 },
                    { 3, "Peter Jackson", "Epik Fantezi", "Yüzüklerin Efendisi: Kralın Dönüşü", 2003 },
                    { 4, "Peter Jackson", "Epik Fantezi", "Hobbit: Beklenmedik Yolculuk", 2012 },
                    { 5, "Peter Jackson", "Epik Fantezi", "Hobbit: Smaug'un Çorak Toprakları", 2013 },
                    { 6, "Peter Jackson", "Epik Fantezi", "Hobbit: Beş Ordunun Savaşı", 2014 },
                    { 7, "Gore Verbinski", "Macera Aksiyon", "Karayip Korsanları: Siyah İnci'nin Laneti", 2003 },
                    { 8, "Gore Verbinski", "Macera Aksiyon", "Karayip Korsanları: Ölü Adamın Sandığı", 2006 },
                    { 9, "Gore Verbinski", "Macera Aksiyon", "Karayip Korsanları: Dünyanın Sonu", 2007 },
                    { 10, "Robb Marshall", "Macera Aksiyon", "Karayip Korsanları: Gizemli Denizlerde", 2011 },
                    { 11, "Espen Sandberg", "Macera Aksiyon", "Karayip Korsanları: Salazar'ın İntikamı", 2017 },
                    { 12, "Mehmet Ada Öztekin", "Dram", "7. Koğuştaki Mucize", 2019 }
                });

            migrationBuilder.InsertData(
                table: "MovieTheaters",
                columns: new[] { "Id", "CinemaId", "Name" },
                values: new object[,]
                {
                    { 1, 12, "Cinemaximum" },
                    { 2, 11, "Meram" },
                    { 3, 10, "Beyoğlu Yeşilçam" },
                    { 4, 9, "Sancaktepe Çamsanpark" },
                    { 5, 8, "Galeria Cine Matriks" },
                    { 6, 7, "Ataköy Paribu Cineverse" },
                    { 7, 6, "Avcılar Pelican Mall Cinema Pink" },
                    { 8, 5, "Metroport Cine VIP" },
                    { 9, 4, "Bakırköy Carousel Cinema Pink" },
                    { 10, 3, "Halkalı 212 Cinemarine" },
                    { 11, 2, "Cinetech Mall Of İstanbul" },
                    { 12, 1, "Beylikdüzü Perla Vista Cinema Pink" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
