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
    public class OrganizerInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizerInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizerInfo.ToListAsync());
        }

        // GET: OrganizerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizerInfo == null)
            {
                return NotFound();
            }

            return View(organizerInfo);
        }

        // GET: OrganizerInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,ContactNumber,ContactEmail")] OrganizerInfo organizerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizerInfo);
        }

        // GET: OrganizerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerInfo = await _context.OrganizerInfo.FindAsync(id);
            if (organizerInfo == null)
            {
                return NotFound();
            }
            return View(organizerInfo);
        }

        // POST: OrganizerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,ContactNumber,ContactEmail")] OrganizerInfo organizerInfo)
        {
            if (id != organizerInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerInfoExists(organizerInfo.ID))
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
            return View(organizerInfo);
        }

        // GET: OrganizerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizerInfo == null)
            {
                return NotFound();
            }

            return View(organizerInfo);
        }

        // POST: OrganizerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizerInfo = await _context.OrganizerInfo.FindAsync(id);
            _context.OrganizerInfo.Remove(organizerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerInfoExists(int id)
        {
            return _context.OrganizerInfo.Any(e => e.ID == id);
        }
    }
}
