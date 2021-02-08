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
    public class OrganizerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Organizer.Include(o => o.OrganizerInfo).Include(o => o.OrganizerRole);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Organizer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer
                .Include(o => o.OrganizerInfo)
                .Include(o => o.OrganizerRole)
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // GET: Organizer/Create
        public IActionResult Create()
        {
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName");
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName");
            return View();
        }

        // POST: Organizer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerID,OrganizerInfoID,OrganizerRoleID")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizer.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizer.OrganizerRoleID);
            return View(organizer);
        }

        // GET: Organizer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizer.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizer.OrganizerRoleID);
            return View(organizer);
        }

        // POST: Organizer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerID,OrganizerInfoID,OrganizerRoleID")] Organizer organizer)
        {
            if (id != organizer.OrganizerInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerExists(organizer.OrganizerInfoID))
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
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizer.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizer.OrganizerRoleID);
            return View(organizer);
        }

        // GET: Organizer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizer
                .Include(o => o.OrganizerInfo)
                .Include(o => o.OrganizerRole)
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // POST: Organizer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizer = await _context.Organizer.FindAsync(id);
            _context.Organizer.Remove(organizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerExists(int id)
        {
            return _context.Organizer.Any(e => e.OrganizerInfoID == id);
        }
    }
}
