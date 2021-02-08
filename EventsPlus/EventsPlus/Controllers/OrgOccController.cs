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
    public class OrgOccController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrgOccController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrgOcc
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrganizersOccupied.Include(o => o.Performances);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrgOcc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgOcc = await _context.OrganizersOccupied
                .Include(o => o.Performances)
                .FirstOrDefaultAsync(m => m.OrganizerID == id);
            if (orgOcc == null)
            {
                return NotFound();
            }

            return View(orgOcc);
        }

        // GET: OrgOcc/Create
        public IActionResult Create()
        {
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location");
            return View();
        }

        // POST: OrgOcc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizersOccupiedID,StartTime,EndTime,OrganizerID,PerformanceID")] OrgOcc orgOcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgOcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", orgOcc.PerformanceID);
            return View(orgOcc);
        }

        // GET: OrgOcc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgOcc = await _context.OrganizersOccupied.FindAsync(id);
            if (orgOcc == null)
            {
                return NotFound();
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", orgOcc.PerformanceID);
            return View(orgOcc);
        }

        // POST: OrgOcc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizersOccupiedID,StartTime,EndTime,OrganizerID,PerformanceID")] OrgOcc orgOcc)
        {
            if (id != orgOcc.OrganizerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgOcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgOccExists(orgOcc.OrganizerID))
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
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", orgOcc.PerformanceID);
            return View(orgOcc);
        }

        // GET: OrgOcc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgOcc = await _context.OrganizersOccupied
                .Include(o => o.Performances)
                .FirstOrDefaultAsync(m => m.OrganizerID == id);
            if (orgOcc == null)
            {
                return NotFound();
            }

            return View(orgOcc);
        }

        // POST: OrgOcc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgOcc = await _context.OrganizersOccupied.FindAsync(id);
            _context.OrganizersOccupied.Remove(orgOcc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgOccExists(int id)
        {
            return _context.OrganizersOccupied.Any(e => e.OrganizerID == id);
        }
    }
}
