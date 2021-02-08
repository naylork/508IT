using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class OrganizersOccupiedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizersOccupiedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizersOccupied
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrganizersOccupied.Include(o => o.Performances);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrganizersOccupied/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .Include(o => o.Performances)
                .FirstOrDefaultAsync(m => m.OrganizerID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // GET: OrganizersOccupied/Create
        public IActionResult Create()
        {
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location");
            return View();
        }

        // POST: OrganizersOccupied/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizersOccupiedID,StartTime,EndTime,OrganizerID,PerformanceID")] OrganizersOccupied organizersOccupied)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizersOccupied);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupied/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied.FindAsync(id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // POST: OrganizersOccupied/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizersOccupiedID,StartTime,EndTime,OrganizerID,PerformanceID")] OrganizersOccupied organizersOccupied)
        {
            if (id != organizersOccupied.OrganizerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizersOccupied);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizersOccupiedExists(organizersOccupied.OrganizerID))
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
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupied/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .Include(o => o.Performances)
                .FirstOrDefaultAsync(m => m.OrganizerID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // POST: OrganizersOccupied/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizersOccupied = await _context.OrganizersOccupied.FindAsync(id);
            _context.OrganizersOccupied.Remove(organizersOccupied);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizersOccupiedExists(int id)
        {
            return _context.OrganizersOccupied.Any(e => e.OrganizerID == id);
        }
    }
}
