using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPlusLTD.Data;
using EventPlusLTD.Models;

namespace Events_LTD.Controllers
{
    public class OrganizersOccupiedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizersOccupiedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizersOccupieds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrganizersOccupied.Include(o => o.Organizer).Include(o => o.Performance);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrganizersOccupieds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .Include(o => o.Organizer)
                .Include(o => o.Performance)
                .FirstOrDefaultAsync(m => m.OrganizersOccupiedID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Create
        public IActionResult Create()
        {
            ViewData["OrganizerID"] = new SelectList(_context.Organizer, "OrganizerID", "OrganizerID");
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID");
            return View();
        }

        // POST: OrganizersOccupieds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerformanceID,OrganizerID,OrganizersOccupiedID,TimeSlotStart,TimeSlotEnd")] OrganizersOccupied organizersOccupied)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizersOccupied);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerID"] = new SelectList(_context.Organizer, "OrganizerID", "OrganizerID", organizersOccupied.OrganizerID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Edit/5
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
            ViewData["OrganizerID"] = new SelectList(_context.Organizer, "OrganizerID", "OrganizerID", organizersOccupied.OrganizerID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // POST: OrganizersOccupieds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerformanceID,OrganizerID,OrganizersOccupiedID,TimeSlotStart,TimeSlotEnd")] OrganizersOccupied organizersOccupied)
        {
            if (id != organizersOccupied.OrganizersOccupiedID)
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
                    if (!OrganizersOccupiedExists(organizersOccupied.OrganizersOccupiedID))
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
            ViewData["OrganizerID"] = new SelectList(_context.Organizer, "OrganizerID", "OrganizerID", organizersOccupied.OrganizerID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", organizersOccupied.PerformanceID);
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .Include(o => o.Organizer)
                .Include(o => o.Performance)
                .FirstOrDefaultAsync(m => m.OrganizersOccupiedID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // POST: OrganizersOccupieds/Delete/5
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
            return _context.OrganizersOccupied.Any(e => e.OrganizersOccupiedID == id);
        }
    }
}
