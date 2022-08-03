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
    public class PracticesController : Controller
    {
        private readonly ApplicationContext _context;

        public PracticesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Practices
        public async Task<IActionResult> Index()
        {
              return _context.Practice != null ? 
                          View(await _context.Practice.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.Practice'  is null.");
        }
        public async Task<IActionResult> ListPractices(int id)
        {
            return _context.Practice != null ?
                        View("Index", await _context.Practice.Where(p => p.MethodologyID == id).ToListAsync()) :
                        Problem("Entity set 'ApplicationContext.Practice'  is null.");
        }
        // GET: Practices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Practice == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice
                .FirstOrDefaultAsync(m => m.PracticeID == id);
            if (practice == null)
            {
                return NotFound();
            }

            return View(practice);
        }

        // GET: Practices/Create
        public IActionResult Create()
        {
            ViewData["MethodologyId"] = new SelectList(_context.Methodology.ToList(),"MethodologyID", "Title");
            return View();
        }

        // POST: Practices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracticeID,Title,Description,MethodologyID")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(practice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practice);
        }

        // GET: Practices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Practice == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice.FindAsync(id);
            ViewData["MethodologyId"] = new SelectList(_context.Methodology.ToList(),"MethodologyID", "Title");
            if (practice == null)
            {
                return NotFound();
            }
            return View(practice);
        }

        // POST: Practices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracticeID,Title,Description,MethodologyID")] Practice practice)
        {
            if (id != practice.PracticeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracticeExists(practice.PracticeID))
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
            return View(practice);
        }

        // GET: Practices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Practice == null)
            {
                return NotFound();
            }

            var practice = await _context.Practice
                .FirstOrDefaultAsync(m => m.PracticeID == id);
            if (practice == null)
            {
                return NotFound();
            }

            return View(practice);
        }

        // POST: Practices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Practice == null)
            {
                return Problem("Entity set 'ApplicationContext.Practice'  is null.");
            }
            var practice = await _context.Practice.FindAsync(id);
            if (practice != null)
            {
                _context.Practice.Remove(practice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracticeExists(int id)
        {
          return (_context.Practice?.Any(e => e.PracticeID == id)).GetValueOrDefault();
        }
    }
}
