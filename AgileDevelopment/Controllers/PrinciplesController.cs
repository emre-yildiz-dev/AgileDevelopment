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
    public class PrinciplesController : Controller
    {
        private readonly ApplicationContext _context;

        public PrinciplesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Principles
        public async Task<IActionResult> Index()
        {
              return _context.Principle != null ? 
                          View(await _context.Principle.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.Principle'  is null.");
        }
        public async Task<IActionResult> ListPrinciples(int id)
        {
            return _context.Principle != null ?
                        View("Index", await _context.Principle.Where(p => p.MethodologyID == id).ToListAsync()) :
                        Problem("Entity set 'ApplicationContext.Principle'  is null.");
        }
        // GET: Principles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Principle == null)
            {
                return NotFound();
            }

            var principle = await _context.Principle
                .FirstOrDefaultAsync(m => m.PrincipleID == id);
            if (principle == null)
            {
                return NotFound();
            }

            return View(principle);
        }

        // GET: Principles/Create
        public IActionResult Create()
        {
            ViewData["MethodologyId"] = new SelectList(_context.Methodology.ToList(), "MethodologyID", "Title");
            return View();
        }

        // POST: Principles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrincipleID,Title,Description,MethodologyID")] Principle principle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(principle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(principle);
        }

        // GET: Principles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Principle == null)
            {
                return NotFound();
            }

            var principle = await _context.Principle.FindAsync(id);
            ViewData["MethodologyId"] = new SelectList(await _context.Methodology.ToListAsync(), "MethodologyID", "Title");
            if (principle == null)
            {
                return NotFound();

            }
            return View(principle);
        }

        // POST: Principles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrincipleID,Title,Description,MethodologyID")] Principle principle)
        {
            if (id != principle.PrincipleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(principle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipleExists(principle.PrincipleID))
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
            return View(principle);
        }

        // GET: Principles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Principle == null)
            {
                return NotFound();
            }

            var principle = await _context.Principle
                .FirstOrDefaultAsync(m => m.PrincipleID == id);
            if (principle == null)
            {
                return NotFound();
            }

            return View(principle);
        }

        // POST: Principles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Principle == null)
            {
                return Problem("Entity set 'ApplicationContext.Principle'  is null.");
            }
            var principle = await _context.Principle.FindAsync(id);
            if (principle != null)
            {
                _context.Principle.Remove(principle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrincipleExists(int id)
        {
          return (_context.Principle?.Any(e => e.PrincipleID == id)).GetValueOrDefault();
        }
    }
}
