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
    public class EquipTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EquipType
        public async Task<IActionResult> Index()
        {
            return View(await _context.EquipmentType.ToListAsync());
        }

        // GET: EquipType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipType = await _context.EquipmentType
                .FirstOrDefaultAsync(m => m.EquipmentTypeID == id);
            if (equipType == null)
            {
                return NotFound();
            }

            return View(equipType);
        }

        // GET: EquipType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentTypeID,Type")] EquipType equipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipType);
        }

        // GET: EquipType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipType = await _context.EquipmentType.FindAsync(id);
            if (equipType == null)
            {
                return NotFound();
            }
            return View(equipType);
        }

        // POST: EquipType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentTypeID,Type")] EquipType equipType)
        {
            if (id != equipType.EquipmentTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipTypeExists(equipType.EquipmentTypeID))
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
            return View(equipType);
        }

        // GET: EquipType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipType = await _context.EquipmentType
                .FirstOrDefaultAsync(m => m.EquipmentTypeID == id);
            if (equipType == null)
            {
                return NotFound();
            }

            return View(equipType);
        }

        // POST: EquipType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipType = await _context.EquipmentType.FindAsync(id);
            _context.EquipmentType.Remove(equipType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipTypeExists(int id)
        {
            return _context.EquipmentType.Any(e => e.EquipmentTypeID == id);
        }
    }
}
