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
    public class ATController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ATController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AT
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActType.ToListAsync());
        }

        // GET: AT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.ActType
                .FirstOrDefaultAsync(m => m.ActTypeID == id);
            if (aT == null)
            {
                return NotFound();
            }

            return View(aT);
        }

        // GET: AT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActTypeID,Genre")] AT aT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aT);
        }

        // GET: AT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.ActType.FindAsync(id);
            if (aT == null)
            {
                return NotFound();
            }
            return View(aT);
        }

        // POST: AT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActTypeID,Genre")] AT aT)
        {
            if (id != aT.ActTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ATExists(aT.ActTypeID))
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
            return View(aT);
        }

        // GET: AT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.ActType
                .FirstOrDefaultAsync(m => m.ActTypeID == id);
            if (aT == null)
            {
                return NotFound();
            }

            return View(aT);
        }

        // POST: AT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aT = await _context.ActType.FindAsync(id);
            _context.ActType.Remove(aT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ATExists(int id)
        {
            return _context.ActType.Any(e => e.ActTypeID == id);
        }
    }
}
