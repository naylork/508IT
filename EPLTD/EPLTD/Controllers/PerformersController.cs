using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPLTD.Data;
using EPLTD.Models;

namespace EPLTD.Controllers
{
    public class PerformersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerformersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Performers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Performers.ToListAsync());
        }

        // GET: Performers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performers = await _context.Performers
                .FirstOrDefaultAsync(m => m.PerformersID == id);
            if (performers == null)
            {
                return NotFound();
            }

            return View(performers);
        }

        // GET: Performers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Performers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,PerformersID,FullName,ContactEmail,ContactNumber")] Performers performers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performers);
        }

        // GET: Performers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performers = await _context.Performers.FindAsync(id);
            if (performers == null)
            {
                return NotFound();
            }
            return View(performers);
        }

        // POST: Performers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreID,PerformersID,FullName,ContactEmail,ContactNumber")] Performers performers)
        {
            if (id != performers.PerformersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformersExists(performers.PerformersID))
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
            return View(performers);
        }

        // GET: Performers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performers = await _context.Performers
                .FirstOrDefaultAsync(m => m.PerformersID == id);
            if (performers == null)
            {
                return NotFound();
            }

            return View(performers);
        }

        // POST: Performers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performers = await _context.Performers.FindAsync(id);
            _context.Performers.Remove(performers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformersExists(int id)
        {
            return _context.Performers.Any(e => e.PerformersID == id);
        }
    }
}
