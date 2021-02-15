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
            var applicationDbContext = _context.AssetsNeeded.Include(a => a.Equipment).Include(a => a.Performance);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssetsNeededs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded
                .Include(a => a.Equipment)
                .Include(a => a.Performance)
                .FirstOrDefaultAsync(m => m.AssetsNeededID == id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }

            return View(assetsNeeded);
        }

        // GET: AssetsNeededs/Create
        public IActionResult Create()
        {
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentID", "Equipment_Name");
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID");
            return View();
        }

        // POST: AssetsNeededs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetsNeededID,PerformanceID,EquipmentID,EstimatedCosts,ActualCosts,AmountNeeded")] AssetsNeeded assetsNeeded)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetsNeeded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", assetsNeeded.PerformanceID);
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
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", assetsNeeded.PerformanceID);
            return View(assetsNeeded);
        }

        // POST: AssetsNeededs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssetsNeededID,PerformanceID,EquipmentID,EstimatedCosts,ActualCosts,AmountNeeded")] AssetsNeeded assetsNeeded)
        {
            if (id != assetsNeeded.AssetsNeededID)
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
                    if (!AssetsNeededExists(assetsNeeded.AssetsNeededID))
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
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "PerformanceID", "PerformanceID", assetsNeeded.PerformanceID);
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
                .Include(a => a.Equipment)
                .Include(a => a.Performance)
                .FirstOrDefaultAsync(m => m.AssetsNeededID == id);
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
            return _context.AssetsNeeded.Any(e => e.AssetsNeededID == id);
        }
    }
}
