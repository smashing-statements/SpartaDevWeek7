﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.Models;

namespace SpartaToDo.Data
{
    public class SpartaToDoContext : IdentityDbContext
    {
        public SpartaToDoContext(DbContextOptions<SpartaToDoContext> options)
            : base(options)
        {

        }
        public SpartaToDoContext()
        {
                
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Spartan> Spartans { get; set; }
    }
}