using ArtGallery.CJ.WEB.Infrastructure.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ArtGallery.CJ.WEB.Infrastructure.Domain
{
    public class ArtDBContext : DbContext
    {
        public ArtDBContext(DbContextOptions<ArtDBContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var salt = BCrypt.BCryptHelper.GenerateSalt();
            List<User> users = new List<User>()
            {
                new User()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Birthdate = DateTime.Parse("11/12/2020"),
                    Email = "JohnJohn@Doemail.com",
                    ContactNumber = "09485209870",
                    Address = "Orani, Bataan",
                    Password = BCrypt.BCryptHelper.HashPassword("SangeYasha",salt),
                    Sex = "Male",
                    UserID = Guid.Parse("d6f01585-5d6a-44ff-aaad-2d8648268582")
                },

                new User()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Birthdate = DateTime.Parse("5/8/1010"),
                    Email = "JaneJane@Doemail.com",
                    ContactNumber = "09485209870",
                    Address = "Dinalupihan, Bataan",
                    Password = BCrypt.BCryptHelper.HashPassword("SangeYasha",salt),
                    Sex = "Female",
                    UserID = Guid.Parse("aca4e15f-379b-44ce-90c0-ce8374cd0cd7")
                }
            };
            modelBuilder.Entity<User>()
            .HasData(users);

            List<Artist> artists = new List<Artist>()
            {
                new Artist()
                {   ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b19f"),
                Name = "Paul Cezanne",
                BirthPlace = "France",
                Age = "91",
                StyleOfWork = "Drawing, Painting",
                },
                new Artist()
                {
                    ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b20f"),
                Name = "Caravaggio",
                BirthPlace = "Italy",
                Age = "94",
                StyleOfWork = "Drawing, Painting, Biography",
                },
                new Artist()
                {
                     ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b11f"),
                Name = "Leonardo Da Vinci",
                BirthPlace = "Italy",
                Age = "52",
                StyleOfWork = "Renaissance man, Universal Genius, Unquenchable curiosity, Feverishly Inventive Imagination",

                },
                new Artist()
                {
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b18f"),
                Name = "Marcel Duchamp",
                BirthPlace = "France",
                Age = "97",
                StyleOfWork = "Painting, Sculpture, Writer, Ches Player",
                },
                new Artist()
                {
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b12f"),
                Name = "Pablo Picasso",
                BirthPlace = "Spain",
                Age = "85",
                StyleOfWork = "Drawing, Painting, Cerematic, Sculpture, Printmaking, Writing, Stage Design",
                },
            };
            modelBuilder.Entity<Artist>()
            .HasData(artists);
            List<Artwork> artworks = new List<Artwork>()

            {
                 new Artwork()
                 {
                     ArtworkID = Guid.NewGuid(),
                     ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b18f"),
                Title = "Nude Descending a Staircase, No. 2 ",
                Year = "1912",
                Content = "sad young man who is in a corridor and who is moving about; thus there are two parallel movements corresponding to each other",
                Medium = "Oil on canvas",
                 },
                 new Artwork()
                {
                ArtworkID = Guid.NewGuid(),
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b19f"),
                Title = "The Bathers",
                Year = "1898–1905",
                Content = "treat nature in terms of the cylinder, the sphere and the cone",
                Medium = "Oil-on-canvas",
                },
                 new Artwork()
                 {
                ArtworkID = Guid.NewGuid(),
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b20f"),
                Title = "The Musicians",
                Year = "1595",
                Content = "painted for the Cardinal youths playing music very well drawn from nature and also a youth playing a lute",
                Medium = "Oil on canvas",
                 },
                 new Artwork()
                 {
                     ArtworkID = Guid.NewGuid(),
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b14f"),
                Title = "Impression, Sunrise",
                Year = "1872",
                Content = "It was intended as disparagement but the Impressionists appropriated the term for themselves",
                Medium = "Oil on canvas",
                 },
                 new Artwork()
                 {
                     ArtworkID = Guid.NewGuid(),
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b15f"),
                Title = "The Prodigal Son in the Brothel",
                Year = "1637",
                Content = " two people who had been identified as Rembrandt himself and his wife Saskia",
                Medium = "Oil on Canvas",
                 },
                 new Artwork()
                 {
                ArtworkID = Guid.NewGuid(),
                ArtistID = Guid.Parse("c8bd6bfd-43df-4d36-930b-463bc154b12f"),
                Title = "The Old Guitarist",
                Year = "1903",
                Content = "The Man with the Blue Guitar",
                Medium = " oil painting ",
                 }
            };
            modelBuilder.Entity<Artwork>()
            .HasData(artworks);

        }
    }
}
