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
    public class OrganizersOccupiedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizersOccupiedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizersOccupieds
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizersOccupied.ToListAsync());
        }

        // GET: OrganizersOccupieds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizersOccupieds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StartTime,EndTime")] OrganizersOccupied organizersOccupied)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizersOccupied);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied.FindAsync(id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }
            return View(organizersOccupied);
        }

        // POST: OrganizersOccupieds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StartTime,EndTime")] OrganizersOccupied organizersOccupied)
        {
            if (id != organizersOccupied.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizersOccupied);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizersOccupiedExists(organizersOccupied.ID))
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
            return View(organizersOccupied);
        }

        // GET: OrganizersOccupieds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizersOccupied = await _context.OrganizersOccupied
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizersOccupied == null)
            {
                return NotFound();
            }

            return View(organizersOccupied);
        }

        // POST: OrganizersOccupieds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizersOccupied = await _context.OrganizersOccupied.FindAsync(id);
            _context.OrganizersOccupied.Remove(organizersOccupied);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizersOccupiedExists(int id)
        {
            return _context.OrganizersOccupied.Any(e => e.ID == id);
        }
    }
}
