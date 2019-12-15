using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorMovie.Data;
using RazorMovie.Models;

namespace RazorMovie
{
    public class CreateModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public CreateModel(RazorMovie.Data.MovieContext context)
        {
            _context = context;
        }
        public Movie.MovieGenre MovieGenre { get; set; }

        public Movie.MovieRating MovieRating { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
