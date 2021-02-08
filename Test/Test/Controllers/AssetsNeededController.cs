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
    public class AssetsNeededController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetsNeededController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetsNeeded
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssetsNeeded.Include(a => a.Equipments).Include(a => a.Performances);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssetsNeeded/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded
                .Include(a => a.Equipments)
                .Include(a => a.Performances)
                .FirstOrDefaultAsync(m => m.PerformanceID == id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }

            return View(assetsNeeded);
        }

        // GET: AssetsNeeded/Create
        public IActionResult Create()
        {
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentTypeID", "Equipment_Name");
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location");
            return View();
        }

        // POST: AssetsNeeded/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetsNeededID,Estimated_Costs,Actual_Costs,Amount_Needed,EquipmentID,PerformanceID")] AssetsNeeded assetsNeeded)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetsNeeded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentTypeID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", assetsNeeded.PerformanceID);
            return View(assetsNeeded);
        }

        // GET: AssetsNeeded/Edit/5
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
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentTypeID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", assetsNeeded.PerformanceID);
            return View(assetsNeeded);
        }

        // POST: AssetsNeeded/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssetsNeededID,Estimated_Costs,Actual_Costs,Amount_Needed,EquipmentID,PerformanceID")] AssetsNeeded assetsNeeded)
        {
            if (id != assetsNeeded.PerformanceID)
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
                    if (!AssetsNeededExists(assetsNeeded.PerformanceID))
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
            ViewData["EquipmentID"] = new SelectList(_context.Equipment, "EquipmentTypeID", "Equipment_Name", assetsNeeded.EquipmentID);
            ViewData["PerformanceID"] = new SelectList(_context.Performance, "EventID", "Performance_Location", assetsNeeded.PerformanceID);
            return View(assetsNeeded);
        }

        // GET: AssetsNeeded/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetsNeeded = await _context.AssetsNeeded
                .Include(a => a.Equipments)
                .Include(a => a.Performances)
                .FirstOrDefaultAsync(m => m.PerformanceID == id);
            if (assetsNeeded == null)
            {
                return NotFound();
            }

            return View(assetsNeeded);
        }

        // POST: AssetsNeeded/Delete/5
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
            return _context.AssetsNeeded.Any(e => e.PerformanceID == id);
        }
    }
}
