using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Models;

namespace RazorMovie
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public IndexModel(RazorMovie.Data.MovieContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string GenreSort { get; set; }
        public string RatingSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public Movie.MovieGenre MovieGenre { get; set; }
        [BindProperty(SupportsGet = true)]
        public Movie.MovieRating MovieRating { get; set; }
       

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        
        public async Task OnGetAsync(string sortOrder)
        {
            
            
            var genreQuery = from m in _context.Movies
                                            orderby m.Genre
                                            select m.Genre;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            RatingSort = sortOrder == "Rating" ? "rating_desc" : "Rating";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            IQueryable<Movie> movies = from s in _context.Movies
                                             select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.ToLower().Contains(SearchString.ToLower()));
            }

            var movieCount = movies.Count();
            
            switch (MovieGenre)
            {
                case RazorMovie.Models.Movie.MovieGenre.Action:
                    // movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Action);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.Comedy:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Comedy);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.Fantasy:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Fantasy);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.FantasySciFi:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.FantasySciFi);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.Horror:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Horror);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.RomanticComedy:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.RomanticComedy);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.SciFiAdventure:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.SciFiAdventure);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.Thriller:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Thriller);
                    break;
                case RazorMovie.Models.Movie.MovieGenre.Western:
                    movies = movies.Where(s => s.Genre == Models.Movie.MovieGenre.Western);
                    break;
                case Models.Movie.MovieGenre.All:
                    break;
            }

            movieCount = movies.Count();

            switch (MovieRating)
            {
                case Models.Movie.MovieRating.PG:
                    movies = movies.Where(s => s.Rating == Models.Movie.MovieRating.PG);
                    break;
                case Models.Movie.MovieRating.PG13:
                    movies = movies.Where(s => s.Rating == Models.Movie.MovieRating.PG13);
                    break;
                case Models.Movie.MovieRating.R:
                    //movies = movies.Where(s => s.Rating == Models.Movie.MovieRating.R);
                    break;
                case Models.Movie.MovieRating.All:
                    break;
                
            }
            movieCount = movies.Count();

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Genre":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "Rating":
                    movies = movies.OrderBy(s => s.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(s => s.Rating);
                        break;
                case "Price":
                    movies = movies.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    movies = movies.OrderByDescending(s => s.Price);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }
            movieCount = movies.Count();
            Movie = await movies.AsNoTracking().ToListAsync();
        }  
        



        
    }
}
 