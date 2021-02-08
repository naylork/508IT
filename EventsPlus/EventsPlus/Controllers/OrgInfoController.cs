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
    public class OrgInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrgInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrgInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizerInfo.ToListAsync());
        }

        // GET: OrgInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (orgInfo == null)
            {
                return NotFound();
            }

            return View(orgInfo);
        }

        // GET: OrgInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrgInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerInfoID,FirstName,LastName,ContactNumber,ContactEmail")] OrgInfo orgInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orgInfo);
        }

        // GET: OrgInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgInfo = await _context.OrganizerInfo.FindAsync(id);
            if (orgInfo == null)
            {
                return NotFound();
            }
            return View(orgInfo);
        }

        // POST: OrgInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerInfoID,FirstName,LastName,ContactNumber,ContactEmail")] OrgInfo orgInfo)
        {
            if (id != orgInfo.OrganizerInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgInfoExists(orgInfo.OrganizerInfoID))
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
            return View(orgInfo);
        }

        // GET: OrgInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (orgInfo == null)
            {
                return NotFound();
            }

            return View(orgInfo);
        }

        // POST: OrgInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgInfo = await _context.OrganizerInfo.FindAsync(id);
            _context.OrganizerInfo.Remove(orgInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgInfoExists(int id)
        {
            return _context.OrganizerInfo.Any(e => e.OrganizerInfoID == id);
        }
    }
}
