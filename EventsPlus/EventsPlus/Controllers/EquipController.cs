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
    public class EquipController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equip
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipment.ToListAsync());
        }

        // GET: Equip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Equipment
                .FirstOrDefaultAsync(m => m.EquipmentTypeID == id);
            if (equip == null)
            {
                return NotFound();
            }

            return View(equip);
        }

        // GET: Equip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentID,Equipment_Name,Availability,EquipmentTypeID")] Equip equip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equip);
        }

        // GET: Equip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Equipment.FindAsync(id);
            if (equip == null)
            {
                return NotFound();
            }
            return View(equip);
        }

        // POST: Equip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentID,Equipment_Name,Availability,EquipmentTypeID")] Equip equip)
        {
            if (id != equip.EquipmentTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipExists(equip.EquipmentTypeID))
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
            return View(equip);
        }

        // GET: Equip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Equipment
                .FirstOrDefaultAsync(m => m.EquipmentTypeID == id);
            if (equip == null)
            {
                return NotFound();
            }

            return View(equip);
        }

        // POST: Equip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equip = await _context.Equipment.FindAsync(id);
            _context.Equipment.Remove(equip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipExists(int id)
        {
            return _context.Equipment.Any(e => e.EquipmentTypeID == id);
        }
    }
}
