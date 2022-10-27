using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTutorialNewApp.Data;
using RazorTutorialNewApp.Models;

namespace RazorTutorialNewApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorTutorialNewApp.Data.RazorTutorialNewAppContext _context;

        public IndexModel(RazorTutorialNewApp.Data.RazorTutorialNewAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
