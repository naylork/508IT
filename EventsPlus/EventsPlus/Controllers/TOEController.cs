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
    public class TOEController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TOEController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TOE
        public async Task<IActionResult> Index()
        {
            var TypeOfEvents = _context.TypeOfEvent
                .AsNoTracking();
            return View(await _context.TypeOfEvent.ToListAsync());
        }

        // GET: TOE/Details/5
//#if ScaffoldedCode
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TOE = await _context.TypeOfEvent
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TypeOfEventID == id);
            if (TOE == null)
            {
                return NotFound();
            }

            return View(TOE);
        }
#elif RawSQL
        #region snippet_RawSQL
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT * FROM Department WHERE DepartmentID = {0}";
            var TOE = await _context.TypeOfEvent
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (TOE == null)
            {
                return NotFound();
            }

            return View(TOE);
        }
        #endregion
#endif
        // GET: TOE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TOE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfEventID,Event_Type")] TOE tOE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tOE);
        }

        // GET: TOE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOE = await _context.TypeOfEvent.FindAsync(id);
            if (tOE == null)
            {
                return NotFound();
            }
            return View(tOE);
        }

        // POST: TOE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfEventID,Event_Type")] TOE tOE)
        {
            if (id != tOE.TypeOfEventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOEExists(tOE.TypeOfEventID))
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
            return View(tOE);
        }

        // GET: TOE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOE = await _context.TypeOfEvent
                .FirstOrDefaultAsync(m => m.TypeOfEventID == id);
            if (tOE == null)
            {
                return NotFound();
            }

            return View(tOE);
        }

        // POST: TOE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOE = await _context.TypeOfEvent.FindAsync(id);
            _context.TypeOfEvent.Remove(tOE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOEExists(int id)
        {
            return _context.TypeOfEvent.Any(e => e.TypeOfEventID == id);
        }
    }
}
