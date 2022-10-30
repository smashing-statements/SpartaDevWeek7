using SpartaToDo.Models;
using SpartaToDo.Models.ViewModels;

namespace SpartaToDo.Controllers
{
    public static class Utils
    {
        public static ToDoViewModel ToDoToToDoVM(ToDo todo) =>
            new ToDoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Complete = todo.Complete
            };

        public static ToDo ToDoToToDoVM(ToDoViewModel todo) =>
            new ToDo
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Complete = todo.Complete
            };
    }
}
