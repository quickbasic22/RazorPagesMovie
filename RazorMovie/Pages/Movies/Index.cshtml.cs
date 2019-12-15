using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Movie> Movie { get;set; }
        
        public async Task OnGetAsync()
        {
            
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
