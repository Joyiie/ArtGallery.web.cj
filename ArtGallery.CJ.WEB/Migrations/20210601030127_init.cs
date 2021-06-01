using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtGallery.CJ.WEB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    StyleOfWork = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistID);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ArtworkID = table.Column<Guid>(nullable: false),
                    ArtistID = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ArtworkID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistID", "Age", "BirthPlace", "Name", "StyleOfWork" },
                values: new object[,]
                {
                    { new Guid("c8bd6bfd-43df-4d36-930b-463bc154b19f"), "91", "France", "Paul Cezanne", "Drawing, Painting" },
                    { new Guid("c8bd6bfd-43df-4d36-930b-463bc154b20f"), "94", "Italy", "Caravaggio", "Drawing, Painting, Biography" },
                    { new Guid("c8bd6bfd-43df-4d36-930b-463bc154b11f"), "52", "Italy", "Leonardo Da Vinci", "Renaissance man, Universal Genius, Unquenchable curiosity, Feverishly Inventive Imagination" },
                    { new Guid("c8bd6bfd-43df-4d36-930b-463bc154b18f"), "97", "France", "Marcel Duchamp", "Painting, Sculpture, Writer, Ches Player" },
                    { new Guid("c8bd6bfd-43df-4d36-930b-463bc154b12f"), "85", "Spain", "Pablo Picasso", "Drawing, Painting, Cerematic, Sculpture, Printmaking, Writing, Stage Design" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "ArtworkID", "ArtistID", "Content", "Medium", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("532ea9f5-d95d-4902-be71-57b7ba7350b5"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b18f"), "sad young man who is in a corridor and who is moving about; thus there are two parallel movements corresponding to each other", "Oil on canvas", "Nude Descending a Staircase, No. 2 ", "1912" },
                    { new Guid("e055bbda-6c14-44db-a63d-f2c2c658ad44"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b19f"), "treat nature in terms of the cylinder, the sphere and the cone", "Oil-on-canvas", "The Bathers", "1898–1905" },
                    { new Guid("e3ba8ee4-24e1-4741-a477-fb6b9e850bb3"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b20f"), "painted for the Cardinal youths playing music very well drawn from nature and also a youth playing a lute", "Oil on canvas", "The Musicians", "1595" },
                    { new Guid("1b5ca85a-eb8f-436b-a6d1-641ee8a13702"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b14f"), "It was intended as disparagement but the Impressionists appropriated the term for themselves", "Oil on canvas", "Impression, Sunrise", "1872" },
                    { new Guid("b86b50ce-9bc7-4470-a4f2-50a4bd878ace"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b15f"), " two people who had been identified as Rembrandt himself and his wife Saskia", "Oil on Canvas", "The Prodigal Son in the Brothel", "1637" },
                    { new Guid("f0946a77-1f0d-47a6-afc4-f7f3bf9e6544"), new Guid("c8bd6bfd-43df-4d36-930b-463bc154b12f"), "The Man with the Blue Guitar", " oil painting ", "The Old Guitarist", "1903" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Birthdate", "ContactNumber", "Email", "FirstName", "LastName", "Password", "Sex", "UserRole" },
                values: new object[,]
                {
                    { new Guid("d6f01585-5d6a-44ff-aaad-2d8648268582"), "Orani, Bataan", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "09485209870", "JohnJohn@Doemail.com", "John", "Doe", "$2b$10$3JybgWnMBTzgO7HJEi6ulOctwgL9E8oIyvmkf65iKm9nabeHo0P.O", "Male", 0 },
                    { new Guid("aca4e15f-379b-44ce-90c0-ce8374cd0cd7"), "Dinalupihan, Bataan", new DateTime(1010, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "09485209870", "JaneJane@Doemail.com", "Jane", "Doe", "$2b$10$3JybgWnMBTzgO7HJEi6ulOctwgL9E8oIyvmkf65iKm9nabeHo0P.O", "Female", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
