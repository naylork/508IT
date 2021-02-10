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
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Participants.Include(p => p.Performance).Include(p => p.Performers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants
                .Include(p => p.Performance)
                .Include(p => p.Performers)
                .FirstOrDefaultAsync(m => m.ParticipantID == id);
            if (participants == null)
            {
                return NotFound();
            }

            return View(participants);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID");
            ViewData["PerformersID"] = new SelectList(_context.Performers, "PerformersID", "FullName");
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipantID,PerformanceID,PerformersID,TimeSlotStart,TimeSlotEnd,EstimatedCosts,ActualCosts")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", participants.PerformanceID);
            ViewData["PerformersID"] = new SelectList(_context.Performers, "PerformersID", "FullName", participants.PerformersID);
            return View(participants);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants.FindAsync(id);
            if (participants == null)
            {
                return NotFound();
            }
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", participants.PerformanceID);
            ViewData["PerformersID"] = new SelectList(_context.Performers, "PerformersID", "FullName", participants.PerformersID);
            return View(participants);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipantID,PerformanceID,PerformersID,TimeSlotStart,TimeSlotEnd,EstimatedCosts,ActualCosts")] Participants participants)
        {
            if (id != participants.ParticipantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantsExists(participants.ParticipantID))
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
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", participants.PerformanceID);
            ViewData["PerformersID"] = new SelectList(_context.Performers, "PerformersID", "FullName", participants.PerformersID);
            return View(participants);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participants = await _context.Participants
                .Include(p => p.Performance)
                .Include(p => p.Performers)
                .FirstOrDefaultAsync(m => m.ParticipantID == id);
            if (participants == null)
            {
                return NotFound();
            }

            return View(participants);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participants = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.ParticipantID == id);
        }
    }
}
