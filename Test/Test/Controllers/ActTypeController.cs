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
    public class ActTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActType.ToListAsync());
        }

        // GET: ActType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActType
                .FirstOrDefaultAsync(m => m.ActTypeID == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // GET: ActType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActTypeID,Genre")] ActType actType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actType);
        }

        // GET: ActType/Edit/5
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

        // POST: ActType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActTypeID,Genre")] ActType actType)
        {
            if (id != actType.ActTypeID)
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
                    if (!ActTypeExists(actType.ActTypeID))
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

        // GET: ActType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActType
                .FirstOrDefaultAsync(m => m.ActTypeID == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // POST: ActType/Delete/5
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
            return _context.ActType.Any(e => e.ActTypeID == id);
        }
    }
}
