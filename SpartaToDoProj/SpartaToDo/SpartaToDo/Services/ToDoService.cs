using Microsoft.EntityFrameworkCore;
using SpartaToDo.Data;
using SpartaToDo.Models;

namespace SpartaToDo.Services
{
    public class ToDoService : IToDoServices
    { 

        private readonly SpartaToDoContext _context;

        public ToDoService(SpartaToDoContext context)
        {
            _context = context;
        }
        public async Task CreateToDoAsync(ToDo item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ToDo> GetToDoAsync(int? id)
        {
            return await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<ToDo>> GetToDosAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public void RemoveToDo(ToDo item)
        {
            _context.ToDos.Remove(item);
            _context.SaveChanges();
        }

        public async Task SaveToDoChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool ToDoExists(int? id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }

        public void UpdateToDo(ToDo item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public async Task UpdateToDoAsync(ToDo item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
