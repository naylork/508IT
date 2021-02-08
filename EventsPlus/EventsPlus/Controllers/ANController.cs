using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlus.Data;
using EventsPlus.Models;

namespace EventsPlus.Controllers
{
    public class ANController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ANController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AN
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetsNeeded.Include(a => a.Performances);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AN/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aN = await _context.AssetsNeeded
                .Include(a => a.Performances)
                .FirstOrDefaultAsync(m => m.PerformanceID == id);
            if (aN == null)
            {
                return NotFound();
            }

            return View(aN);
        }

        // GET: AN/Create
        public IActionResult Create()
        {
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location");
            return View();
        }

        // POST: AN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AN_ID,Estimated_Costs,Actual_Costs,Amount_Needed,EquipmentID,PerformanceID")] AN aN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", aN.PerformanceID);
            return View(aN);
        }

        // GET: AN/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aN = await _context.AssetsNeeded.FindAsync(id);
            if (aN == null)
            {
                return NotFound();
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", aN.PerformanceID);
            return View(aN);
        }

        // POST: AN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AN_ID,Estimated_Costs,Actual_Costs,Amount_Needed,EquipmentID,PerformanceID")] AN aN)
        {
            if (id != aN.PerformanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ANExists(aN.PerformanceID))
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
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", aN.PerformanceID);
            return View(aN);
        }

        // GET: AN/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aN = await _context.AssetsNeeded
                .Include(a => a.Performances)
                .FirstOrDefaultAsync(m => m.PerformanceID == id);
            if (aN == null)
            {
                return NotFound();
            }

            return View(aN);
        }

        // POST: AN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aN = await _context.AssetsNeeded.FindAsync(id);
            _context.AssetsNeeded.Remove(aN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ANExists(int id)
        {
            return _context.AssetsNeeded.Any(e => e.PerformanceID == id);
        }
    }
}
