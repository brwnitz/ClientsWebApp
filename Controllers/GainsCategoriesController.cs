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
    public class GainsCategoriesController : Controller
    {
       

        private readonly ApplicationDbContext _context;

       

        public GainsCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GainsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GainsCategory.ToListAsync());
        }

        // GET: GainsCategories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gainsCategory = await _context.GainsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gainsCategory == null)
            {
                return NotFound();
            }

            return View(gainsCategory);
        }

        // GET: GainsCategories/Create
        

        // POST: GainsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gain")] GainsCategory gainsCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gainsCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gainsCategory);
        }

        // GET: GainsCategories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gainsCategory = await _context.GainsCategory.FindAsync(id);
            if (gainsCategory == null)
            {
                return NotFound();
            }
            return View(gainsCategory);
        }

        // POST: GainsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Gain")] GainsCategory gainsCategory)
        {
            if (id != gainsCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gainsCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GainsCategoryExists(gainsCategory.Id))
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
            return View(gainsCategory);
        }

        // GET: GainsCategories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gainsCategory = await _context.GainsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gainsCategory == null)
            {
                return NotFound();
            }

            return View(gainsCategory);
        }

        // POST: GainsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gainsCategory = await _context.GainsCategory.FindAsync(id);
            _context.GainsCategory.Remove(gainsCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GainsCategoryExists(string id)
        {
            return _context.GainsCategory.Any(e => e.Id == id);
        }
    }
}
