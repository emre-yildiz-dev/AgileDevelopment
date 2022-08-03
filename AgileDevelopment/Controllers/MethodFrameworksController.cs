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
    public class MethodFrameworksController : Controller
    {
        private readonly ApplicationContext _context;

        public MethodFrameworksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MethodFrameworks
        public async Task<IActionResult> Index()
        {
              return _context.MethodFrameworks != null ? 
                          View(await _context.MethodFrameworks.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.MethodFrameworks'  is null.");
        }
        public async Task<IActionResult> ListMethodFrameworks(int id)
        {
            return _context.MethodFrameworks != null ?
                        View("Index", await _context.MethodFrameworks.Where(mf => mf.MethodologyID == id).ToListAsync()) :
                        Problem("Entity set 'ApplicationContext.MethodFrameworks'  is null.");
        }
        // GET: MethodFrameworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MethodFrameworks == null)
            {
                return NotFound();
            }

            var methodFramework = await _context.MethodFrameworks
                .FirstOrDefaultAsync(m => m.MethodFrameworkID == id);
            if (methodFramework == null)
            {
                return NotFound();
            }

            return View(methodFramework);
        }

        // GET: MethodFrameworks/Create
        public IActionResult Create()
        {
            ViewData["MethodologyId"] = new SelectList(_context.Methodology.ToList(),"MethodologyID", "Title");
            return View();
        }

        // POST: MethodFrameworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MethodFrameworkID,Title,Description,MethodologyID")] MethodFramework methodFramework)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodFramework);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(methodFramework);
        }

        // GET: MethodFrameworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MethodFrameworks == null)
            {
                return NotFound();
            }

            var methodFramework = await _context.MethodFrameworks.FindAsync(id);
            if (methodFramework == null)
            {
                return NotFound();
            }
            return View(methodFramework);
        }

        // POST: MethodFrameworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MethodFrameworkID,Title,Description,MethodologyID")] MethodFramework methodFramework)
        {
            if (id != methodFramework.MethodFrameworkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodFramework);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodFrameworkExists(methodFramework.MethodFrameworkID))
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
            return View(methodFramework);
        }

        // GET: MethodFrameworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MethodFrameworks == null)
            {
                return NotFound();
            }

            var methodFramework = await _context.MethodFrameworks
                .FirstOrDefaultAsync(m => m.MethodFrameworkID == id);
            if (methodFramework == null)
            {
                return NotFound();
            }

            return View(methodFramework);
        }

        // POST: MethodFrameworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MethodFrameworks == null)
            {
                return Problem("Entity set 'ApplicationContext.MethodFrameworks'  is null.");
            }
            var methodFramework = await _context.MethodFrameworks.FindAsync(id);
            if (methodFramework != null)
            {
                _context.MethodFrameworks.Remove(methodFramework);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodFrameworkExists(int id)
        {
          return (_context.MethodFrameworks?.Any(e => e.MethodFrameworkID == id)).GetValueOrDefault();
        }
    }
}
