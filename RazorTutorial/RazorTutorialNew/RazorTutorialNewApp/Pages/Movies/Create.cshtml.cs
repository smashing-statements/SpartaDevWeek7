using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorTutorialNewApp.Data;
using RazorTutorialNewApp.Models;

namespace RazorTutorialNewApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorTutorialNewApp.Data.RazorTutorialNewAppContext _context;

        public CreateModel(RazorTutorialNewApp.Data.RazorTutorialNewAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        //this opts in to model binding
        //this binds posted values
        //to the Movie model
        [BindProperty]
        public Movie Movie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
