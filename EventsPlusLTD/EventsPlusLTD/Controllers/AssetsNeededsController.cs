using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlusLTD.Data;
using EventsPlusLTD.Models;

namespace EventsPlusLTD.Controllers
{
    public class AssetsNeededsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetsNeededsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetsNeededs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetsNeeded.ToListAsync());
        }

        // GET: AssetsNeededs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded
                .FirstOrDefaultAsync(m => m.ID == id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }

            return View(assetsNeeded);
        }

        // GET: AssetsNeededs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetsNeededs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Estimated_Costs,Actual_Costs,Amount_Needed")] AssetsNeeded assetsNeeded)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetsNeeded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetsNeeded);
        }

        // GET: AssetsNeededs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded.FindAsync(id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }
            return View(assetsNeeded);
        }

        // POST: AssetsNeededs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Estimated_Costs,Actual_Costs,Amount_Needed")] AssetsNeeded assetsNeeded)
        {
            if (id != assetsNeeded.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetsNeeded);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetsNeededExists(assetsNeeded.ID))
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
            return View(assetsNeeded);
        }

        // GET: AssetsNeededs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded
                .FirstOrDefaultAsync(m => m.ID == id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }

            return View(assetsNeeded);
        }

        // POST: AssetsNeededs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetsNeeded = await _context.AssetsNeeded.FindAsync(id);
            _context.AssetsNeeded.Remove(assetsNeeded);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetsNeededExists(int id)
        {
            return _context.AssetsNeeded.Any(e => e.ID == id);
        }
    }
}
