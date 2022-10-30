using SpartaToDo.Models;

namespace SpartaToDo.Services
{
    public interface IToDoServices
    {

        public Task<List<ToDo>> GetToDosAsync();
        public Task<ToDo> GetToDoAsync(int? id);
        public Task CreateToDoAsync(ToDo item);
        public Task SaveToDoChangesAsync();
        public void RemoveToDo(ToDo item);
        public void UpdateToDo(ToDo item);
        public bool ToDoExists(int? id);
    }

}
