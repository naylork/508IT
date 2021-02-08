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
    public class EventLocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventLocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventLoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventLocation.ToListAsync());
        }

        // GET: EventLoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLoc = await _context.EventLocation
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eventLoc == null)
            {
                return NotFound();
            }

            return View(eventLoc);
        }

        // GET: EventLoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventLoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventLocationID,Venue,Capacity,Location_Address,EventID")] EventLoc eventLoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventLoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventLoc);
        }

        // GET: EventLoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLoc = await _context.EventLocation.FindAsync(id);
            if (eventLoc == null)
            {
                return NotFound();
            }
            return View(eventLoc);
        }

        // POST: EventLoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventLocationID,Venue,Capacity,Location_Address,EventID")] EventLoc eventLoc)
        {
            if (id != eventLoc.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventLoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLocExists(eventLoc.EventID))
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
            return View(eventLoc);
        }

        // GET: EventLoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLoc = await _context.EventLocation
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eventLoc == null)
            {
                return NotFound();
            }

            return View(eventLoc);
        }

        // POST: EventLoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventLoc = await _context.EventLocation.FindAsync(id);
            _context.EventLocation.Remove(eventLoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLocExists(int id)
        {
            return _context.EventLocation.Any(e => e.EventID == id);
        }
    }
}
