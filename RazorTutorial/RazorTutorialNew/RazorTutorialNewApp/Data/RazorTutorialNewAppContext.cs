using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTutorialNewApp.Models;

namespace RazorTutorialNewApp.Data
{
    public class RazorTutorialNewAppContext : DbContext
    {
        public RazorTutorialNewAppContext (DbContextOptions<RazorTutorialNewAppContext> options)
            : base(options)
        {
        }

        public DbSet<RazorTutorialNewApp.Models.Movie> Movie { get; set; } = default!;
    }
}
