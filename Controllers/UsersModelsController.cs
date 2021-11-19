using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientsWebApp.Data;
using ClientsWebApp.Models;

namespace ClientsWebApp.Controllers
{
    public class UsersModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsersModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersModel.ToListAsync());
        }

        // GET: UsersModels/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        public async Task<IActionResult> ShowSearchResults(String SearchName)
        {
            return View("Index",await _context.UsersModel.Where( j => j.Name.Contains(SearchName)).ToListAsync());
        }

        // GET: UsersModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.UsersModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

       
        // GET: UsersModels/Create
        public ActionResult Create()
        {
            
            return View();
        }
       

        // POST: UsersModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Gastos,Ganhos")] UsersModel usersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usersModel);
        }

        // GET: UsersModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.UsersModel.FindAsync(id);
            if (usersModel == null)
            {
                return NotFound();
            }
            return View(usersModel);
        }

        // POST: UsersModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Gastos,Ganhos")] UsersModel usersModel)
        {
            if (id != usersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersModelExists(usersModel.Id))
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
            return View(usersModel);
        }

        // GET: UsersModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.UsersModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

        // POST: UsersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersModel = await _context.UsersModel.FindAsync(id);
            _context.UsersModel.Remove(usersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersModelExists(int id)
        {
            return _context.UsersModel.Any(e => e.Id == id);
        }
    }
}
