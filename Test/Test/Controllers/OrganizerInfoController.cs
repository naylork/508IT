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
    public class OrganizerInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizerInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizerInfo.ToListAsync());
        }

        // GET: OrganizerInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizerInfo == null)
            {
                return NotFound();
            }

            return View(organizerInfo);
        }

        // GET: OrganizerInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizerInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerInfoID,FirstName,LastName,ContactNumber,ContactEmail")] OrganizerInfo organizerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizerInfo);
        }

        // GET: OrganizerInfo/Edit/5
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

        // POST: OrganizerInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerInfoID,FirstName,LastName,ContactNumber,ContactEmail")] OrganizerInfo organizerInfo)
        {
            if (id != organizerInfo.OrganizerInfoID)
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
                    if (!OrganizerInfoExists(organizerInfo.OrganizerInfoID))
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

        // GET: OrganizerInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerInfo = await _context.OrganizerInfo
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizerInfo == null)
            {
                return NotFound();
            }

            return View(organizerInfo);
        }

        // POST: OrganizerInfo/Delete/5
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
            return _context.OrganizerInfo.Any(e => e.OrganizerInfoID == id);
        }
    }
}
