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
    public class ActTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActType.ToListAsync());
        }

        // GET: ActTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActType
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // GET: ActTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,Genre")] ActType actType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actType);
        }

        // GET: ActTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActType.FindAsync(id);
            if (actType == null)
            {
                return NotFound();
            }
            return View(actType);
        }

        // POST: ActTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreID,Genre")] ActType actType)
        {
            if (id != actType.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActTypeExists(actType.GenreID))
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
            return View(actType);
        }

        // GET: ActTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActType
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // POST: ActTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actType = await _context.ActType.FindAsync(id);
            _context.ActType.Remove(actType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActTypeExists(int id)
        {
            return _context.ActType.Any(e => e.GenreID == id);
        }
    }
}
