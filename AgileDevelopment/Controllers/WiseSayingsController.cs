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
    public class WiseSayingsController : Controller
    {
        private readonly ApplicationContext _context;

        public WiseSayingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: WiseSayings
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.WiseSaying.Include(w => w.Methodology);
            return View(await applicationContext.ToListAsync());
        }
        public async Task<IActionResult> ListWiseSayings(int id)
        {
            var applicationContext = _context.WiseSaying.Include(w => w.Methodology);
            return View("Index", await applicationContext.Where(w => w.MethodologyID == id).ToListAsync());
        }
        // GET: WiseSayings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WiseSaying == null)
            {
                return NotFound();
            }

            var wiseSaying = await _context.WiseSaying
                .Include(w => w.Methodology)
                .FirstOrDefaultAsync(m => m.WiseSayingID == id);
            if (wiseSaying == null)
            {
                return NotFound();
            }

            return View(wiseSaying);
        }

        // GET: WiseSayings/Create
        public IActionResult Create()
        {
            ViewData["MethodologyID"] = new SelectList(_context.Methodology, "MethodologyID", "Title");
            return View();
        }

        // POST: WiseSayings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WiseSayingID,Title,MethodologyID")] WiseSaying wiseSaying)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiseSaying);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MethodologyID"] = new SelectList(_context.Methodology, "MethodologyID", "MethodologyID", wiseSaying.MethodologyID);
            return View(wiseSaying);
        }

        // GET: WiseSayings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WiseSaying == null)
            {
                return NotFound();
            }

            var wiseSaying = await _context.WiseSaying.FindAsync(id);
            if (wiseSaying == null)
            {
                return NotFound();
            }
            ViewData["MethodologyID"] = new SelectList(_context.Methodology, "MethodologyID", "Title", wiseSaying.MethodologyID);
            return View(wiseSaying);
        }

        // POST: WiseSayings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WiseSayingID,Title,MethodologyID")] WiseSaying wiseSaying)
        {
            if (id != wiseSaying.WiseSayingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiseSaying);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WiseSayingExists(wiseSaying.WiseSayingID))
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
            ViewData["MethodologyID"] = new SelectList(_context.Methodology, "MethodologyID", "Title", wiseSaying.MethodologyID);
            return View(wiseSaying);
        }

        // GET: WiseSayings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WiseSaying == null)
            {
                return NotFound();
            }

            var wiseSaying = await _context.WiseSaying
                .Include(w => w.Methodology)
                .FirstOrDefaultAsync(m => m.WiseSayingID == id);
            if (wiseSaying == null)
            {
                return NotFound();
            }

            return View(wiseSaying);
        }

        // POST: WiseSayings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WiseSaying == null)
            {
                return Problem("Entity set 'ApplicationContext.WiseSaying'  is null.");
            }
            var wiseSaying = await _context.WiseSaying.FindAsync(id);
            if (wiseSaying != null)
            {
                _context.WiseSaying.Remove(wiseSaying);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WiseSayingExists(int id)
        {
          return (_context.WiseSaying?.Any(e => e.WiseSayingID == id)).GetValueOrDefault();
        }
    }
}
