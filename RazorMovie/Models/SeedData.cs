using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorMovie.Data;
using RazorMovie.Models;



namespace RazorMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                  context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = Movie.MovieGenre.RomanticComedy,
                        Rating = Movie.MovieRating.R,
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = Movie.MovieGenre.Comedy,
                        Rating = Movie.MovieRating.PG13,
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = Movie.MovieGenre.Comedy,
                        Rating = Movie.MovieRating.PG13,
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = Movie.MovieGenre.Western,
                        Rating = Movie.MovieRating.PG,
                        Price = 3.99M
                    });
                    context.SaveChanges();
            }
        }
    }
}
