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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
#if ScaffoldedCode
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Event
                 .Include(c => c.TypeOfEvent)
                 .AsNoTracking();
            return View(await ApplicationDbContext.ToListAsync());
        }
#elif RevisedIndexMethod
        #region snippet_RevisedIndexMethod
        public async Task<IActionResult> Index()
        {
            var Events = _context.Event
                .Include(c => c.TypeOfEvent)
                .AsNoTracking();
            return View(await Events.ToListAsync());
        }
        #endregion
#endif


        // GET: Events/Details/5
        #region snippet_Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Events = await _context.Event
                .Include(c => c.TypeOfEvent)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (Events == null)
            {
                return NotFound();
            }

            return View(Events);
        }
        #endregion

        // GET: Events/Create
        #region snippet_CreateGet
        public IActionResult Create()
        {
            PopulateTypeOfEventDropDownList();
            return View();
        }
        #endregion

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Event_Name,Event_Description,Start_Date,End_Date,StartTime,EndTime,TypeOfEventID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Event_Name,Event_Description,Start_Date,End_Date,StartTime,EndTime,TypeOfEventID")] Event @event)
        {
            if (id != @event.TypeOfEventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.TypeOfEventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.TypeOfEventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.TypeOfEventID == id);
        }
    }
}
