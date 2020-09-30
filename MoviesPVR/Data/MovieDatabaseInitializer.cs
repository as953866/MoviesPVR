using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    // Class To Seed INitial Movie Data
    public class MovieDatabaseInitializer:DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {
            GetGenres().ForEach(c => context.Genres.Add(c));
            GetMovies().ForEach(p => context.Movies.Add(p));
            User adminUser = new User
            {
                AccountID = "none",
                UserID = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "Pa$$word",
                RoleName = "administrator"
            };
            context.Users.Add(adminUser);
        }

        private static List<Genre> GetGenres()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    GenreID = 1,
                    GenreName = "Science Fiction"
                },
                new Genre
                {
                    GenreID = 2,
                    GenreName = "Others"
                }
            };
            return genres;
        }
        private static List<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    MovieID = 1,
                    MovieName = "Aquaman",
                    Description = "Half-human, half-Atlantean Arthur is born with the ability to communicate with marine creatures. He goes on a quest to retrieve the legendary Trident of Atlan and protect the water world.",
                    ImagePath = "aquaman.JPG",
                    RunningStatus = true,
                    GenreID = 2
                },
                new Movie
                {
                    MovieID = 2,
                    MovieName = "Black Panther",
                    Description = "After his father's death, T'Challa returns home to Wakanda to inherit his throne. However, a powerful enemy related to his family threatens to attack his nation.",
                    ImagePath = "black_panther.JPG",
                    RunningStatus = true,
                    GenreID = 1
                },
                new Movie
                {
                    MovieID = 3,
                    MovieName = "Captain Marvel",
                    Description = "Amidst a mission, Vers, a Kree warrior, gets separated from her team and is stranded on Earth. However, her life takes an unusual turn after she teams up with Fury, a S.H.I.E.L.D. agent.",
                    ImagePath = "captial_marvel.JPG",
                    RunningStatus = true,
                    GenreID = 1
                },
                new Movie
                {
                    MovieID = 4,
                    MovieName = "First Man",
                    Description = "Neil Armstrong, an American NASA test pilot, and his fellow Apollo Program team-members zip themselves into insulated suits and set out on a mission to land on the moon.",
                    ImagePath = "first_man.JPG",
                    RunningStatus = true,
                    GenreID = 2
                },
                new Movie
                {
                    MovieID = 5,
                    MovieName = "Joker",
                    Description = "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks -- the one he paints for his day job as a clown, and the guise he projects in a futile attempt to feel like he's part of the world around him. Isolated, bullied and disregarded by society, Fleck begins a slow descent into madness as he transforms into the criminal mastermind known as the Joker.",
                    ImagePath = "joker.JPG",
                    RunningStatus = true,
                    GenreID = 2
                },
                new Movie
                {
                    MovieID = 6,
                    MovieName = "Replicas",
                    Description = "William Foster is a brilliant neuroscientist who loses his wife, son and two daughters in a tragic car accident. Utilising cutting-edge technology, William comes up with a daring and unprecedented plan to download their memories and clone their bodies. As the experiment begins to spiral out of control, Foster soon finds himself at odds with his dubious boss, a reluctant accomplice, a police task force and the physical laws of science.",
                    ImagePath = "replicas.JPG",
                    RunningStatus = true,
                    GenreID = 1
                },
                new Movie
                {
                    MovieID = 7,
                    MovieName = "The Walk",
                    Description = "Philippe Petit, a French street performer, dreams of performing daring stunts. He attempts to walk between the Twin Towers of the World Trade Center in New York on a tightrope.",
                    ImagePath = "the_walk.JPG",
                    RunningStatus = true,
                    GenreID = 2
                }
            };
            return movies;
        }
    }
}