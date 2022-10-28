using Microsoft.EntityFrameworkCore;
using SpartaToDo.Models;

namespace SpartaToDo.Data
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new SpartaToDoContext(serviceProvider.GetRequiredService<DbContextOptions<SpartaToDoContext>>()))
            {
                if (db.ToDos.Any())
                {
                    return; //db already has data in it
                }

                db.ToDos.AddRange
                    (
                    new ToDo
                    {
                        Title = "Teach C#",
                        Description = "Teach Eng128/151 has to use ASP.NET MVC",
                        Complete = true,
                        Date = new DateTime(2022, 10, 28)
                    },

                    new ToDo
                    {
                        Title = "Sleep",
                        Description = "Go skleep",
                        Complete = true
                    }
                    );

                db.SaveChanges();


            }
        }
    }
}