using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.Data;
using SpartaToDo.Models;
using SpartaToDo.Models.ViewModels;
using SpartaToDo.Services;

namespace SpartaToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoServices _service;
        public ToDoController(IToDoServices service, ILogger<ToDoController> logger)
        {
            _logger = logger;
            _service = service;
        }

        // GET: ToDo
        //even though the signature is
        //Task<IActionResult>, it reutrns
        //a view 
        public async Task<IActionResult> Index()
        {
            var toDos = await _service.GetToDosAsync();
            var toDosViewModels = new List<ToDoViewModel>();
            foreach (var item in toDos)
            {
                toDosViewModels.Add(Utils.ToDoToToDoVM(item));
            }
              return View(toDosViewModels);
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.GetToDosAsync() == null)
            {
                return NotFound();
            }

            var toDo = await _service.GetToDoAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //A form from another site could submit
        //hidden content on a user's behalf 
        //containing harmful data
        //the validate anti forgery attribute
        //prevents this

        //Bind can be applied to a method parameter.
        //This sepcifies that the information passed
        //should be bound to the model
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Complete,Date")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateToDoAsync(toDo);
                await _service.SaveToDoChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.GetToDosAsync == null)
            {
                return NotFound();                                                
            }

            var toDo = await _service.GetToDoAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Complete,Date")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateToDo(toDo);
                    await _service.SaveToDoChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var toDo = await _service.GetToDoAsync(id);
            _service.RemoveToDo(toDo);
            await _service.SaveToDoChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// GET: ToDo/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ToDos == null)
        //    {
        //        return NotFound();
        //    }

        //    var toDo = await _context.ToDos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (toDo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(toDo);
        //}

        //// POST: ToDo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.ToDos == null)
        //    {
        //        return Problem("Entity set 'SpartaToDoContext.ToDos'  is null.");
        //    }
        //    var toDo = await _context.ToDos.FindAsync(id);
        //    if (toDo != null)
        //    {
        //        _context.ToDos.Remove(toDo);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ToDoExists(int id)
        {
            return _service.ToDoExists(id);
        }
    }
}
