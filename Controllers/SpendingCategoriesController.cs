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
    public class SpendingCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        

        public SpendingCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpendingCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpendingCategory.ToListAsync());
        }

        // GET: SpendingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingCategory = await _context.SpendingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spendingCategory == null)
            {
                return NotFound();
            }

            return View(spendingCategory);
        }

        

        // GET: SpendingCategories/Create
        
        // POST: SpendingCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Spending")] SpendingCategory spendingCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spendingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spendingCategory);
        }

        // GET: SpendingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingCategory = await _context.SpendingCategory.FindAsync(id);
            if (spendingCategory == null)
            {
                return NotFound();
            }
            return View(spendingCategory);
        }

        // POST: SpendingCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Spending")] SpendingCategory spendingCategory)
        {
            if (id != spendingCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spendingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpendingCategoryExists(spendingCategory.Id))
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
            return View(spendingCategory);
        }

        // GET: SpendingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingCategory = await _context.SpendingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spendingCategory == null)
            {
                return NotFound();
            }

            return View(spendingCategory);
        }

        // POST: SpendingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spendingCategory = await _context.SpendingCategory.FindAsync(id);
            _context.SpendingCategory.Remove(spendingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpendingCategoryExists(int id)
        {
            return _context.SpendingCategory.Any(e => e.Id == id);
        }
    }
}
