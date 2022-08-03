using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgileDevelopment.Data;
using AgileDevelopment.Models;
using AgileDevelopment.Services;

namespace AgileDevelopment.Controllers
{
    public class MindSetsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMindSetService _mindSetService;

        public MindSetsController(ApplicationContext context, IMindSetService mindSetService)
        {
            _context = context;
            _mindSetService = mindSetService;
        }

        // GET: MindSets
        public async Task<IActionResult> Index()
        {
            return _context.MindSet != null ?
                        View(await _context.MindSet.ToListAsync()) :
                        Problem("Entity set 'ApplicationContext.MindSet'  is null.");
        }
        public async Task<IActionResult> ListMindSets(int id, int methodologyId)
        {
            var mindSets = await _context.MindSet.ToListAsync();
            return _context.MindSet != null ?
                       // View("Index", await _context.MindSet.Where(ms => ms.MemberID == id && ms.Member.MethodologyID == methodologyId).ToListAsync()) :
                       View("Index", _mindSetService.FilterMindSetsByMemberId(id, mindSets)) :
                        Problem("Entity set 'ApplicationContext.MindSet'  is null.");
        }

        // GET: MindSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MindSet == null)
            {
                return NotFound();
            }

            var mindSet = await _context.MindSet
                .FirstOrDefaultAsync(m => m.MindSetID == id);
            if (mindSet == null)
            {
                return NotFound();
            }

            return View(mindSet);
        }

        // GET: MindSets/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Member.ToList(), "MemberID", "Title");
            return View();
        }

        // POST: MindSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MindSetID,Title,Description,MemberID")] MindSet mindSet)
        {
            Member member = await _context.Member.FirstOrDefaultAsync(m => m.MemberID == mindSet.MemberID);
            mindSet.Member = member;
            if (ModelState.IsValid)
            {
                _context.Add(mindSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mindSet);
        }

        // GET: MindSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MindSet == null)
            {
                return NotFound();
            }

            var mindSet = await _context.MindSet.FindAsync(id);
            ViewData["MemberId"] = new SelectList(_context.Member.ToList(), "MemberID", "Title");
            if (mindSet == null)
            {
                return NotFound();
            }
            return View(mindSet);
        }

        // POST: MindSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MindSetID,Title,Description,MemberID")] MindSet mindSet)
        {
            Member member = await _context.Member.FirstOrDefaultAsync(m => m.MemberID == mindSet.MemberID);
            mindSet.Member = member;
            if (id != mindSet.MindSetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mindSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MindSetExists(mindSet.MindSetID))
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
            return View(mindSet);
        }

        // GET: MindSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MindSet == null)
            {
                return NotFound();
            }

            var mindSet = await _context.MindSet
                .FirstOrDefaultAsync(m => m.MindSetID == id);
            if (mindSet == null)
            {
                return NotFound();
            }

            return View(mindSet);
        }

        // POST: MindSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MindSet == null)
            {
                return Problem("Entity set 'ApplicationContext.MindSet'  is null.");
            }
            var mindSet = await _context.MindSet.FindAsync(id);
            if (mindSet != null)
            {
                _context.MindSet.Remove(mindSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MindSetExists(int id)
        {
            return (_context.MindSet?.Any(e => e.MindSetID == id)).GetValueOrDefault();
        }
    }
}
