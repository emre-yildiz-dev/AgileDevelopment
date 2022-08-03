using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgileDevelopment.Data;
using AgileDevelopment.Models;

namespace AgileDevelopment.Controllers
{
    public class MethodologiesController : Controller
    {
        private readonly ApplicationContext _context;

        public MethodologiesController(ApplicationContext context)
        {
            _context = context;
        }


        // GET: Methodologies
        public async Task<IActionResult> Index()
        {
              return _context.Methodology != null ? 
                          View(await _context.Methodology.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.Methodology'  is null.");
        }

        // GET: Methodologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Methodology == null)
            {
                return NotFound();
            }

            var methodology = await _context.Methodology
                .FirstOrDefaultAsync(m => m.MethodologyID == id);
            if (methodology == null)
            {
                return NotFound();
            }

            return View(methodology);
        }

        // GET: Methodologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Methodologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MethodologyID,Title,Description")] Methodology methodology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(methodology);
        }

        // GET: Methodologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Methodology == null)
            {
                return NotFound();
            }

            var methodology = await _context.Methodology.FindAsync(id);
            if (methodology == null)
            {
                return NotFound();
            }
            return View(methodology);
        }

        // POST: Methodologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MethodologyID,Title,Description")] Methodology methodology)
        {
            if (id != methodology.MethodologyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodologyExists(methodology.MethodologyID))
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
            return View(methodology);
        }

        // GET: Methodologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Methodology == null)
            {
                return NotFound();
            }

            var methodology = await _context.Methodology
                .FirstOrDefaultAsync(m => m.MethodologyID == id);
            if (methodology == null)
            {
                return NotFound();
            }

            return View(methodology);
        }

        // POST: Methodologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Methodology == null)
            {
                return Problem("Entity set 'ApplicationContext.Methodology'  is null.");
            }
            var methodology = await _context.Methodology.FindAsync(id);
            if (methodology != null)
            {
                _context.Methodology.Remove(methodology);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodologyExists(int id)
        {
          return (_context.Methodology?.Any(e => e.MethodologyID == id)).GetValueOrDefault();
        }
    }
}
