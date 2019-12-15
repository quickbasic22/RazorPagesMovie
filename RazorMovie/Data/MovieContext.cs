using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorMovie.Models;


namespace RazorMovie.Data
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options): base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
