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
    public class OrganizersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Organizer.Include(o => o.OrganizerInfo).Include(o => o.OrganizerRole);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Organizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizers = await _context.Organizer
                .Include(o => o.OrganizerInfo)
                .Include(o => o.OrganizerRole)
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizers == null)
            {
                return NotFound();
            }

            return View(organizers);
        }

        // GET: Organizers/Create
        public IActionResult Create()
        {
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName");
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName");
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerID,OrganizerInfoID,OrganizerRoleID")] Organizers organizers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizers.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizers.OrganizerRoleID);
            return View(organizers);
        }

        // GET: Organizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizers = await _context.Organizer.FindAsync(id);
            if (organizers == null)
            {
                return NotFound();
            }
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizers.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizers.OrganizerRoleID);
            return View(organizers);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerID,OrganizerInfoID,OrganizerRoleID")] Organizers organizers)
        {
            if (id != organizers.OrganizerInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizersExists(organizers.OrganizerInfoID))
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
            ViewData["OrganizerInfoID"] = new SelectList(_context.OrganizerInfo, "OrganizerInfoID", "FirstName", organizers.OrganizerInfoID);
            ViewData["OrganizerRoleID"] = new SelectList(_context.OrganizerRole, "OrganizerRoleID", "RoleName", organizers.OrganizerRoleID);
            return View(organizers);
        }

        // GET: Organizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizers = await _context.Organizer
                .Include(o => o.OrganizerInfo)
                .Include(o => o.OrganizerRole)
                .FirstOrDefaultAsync(m => m.OrganizerInfoID == id);
            if (organizers == null)
            {
                return NotFound();
            }

            return View(organizers);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizers = await _context.Organizer.FindAsync(id);
            _context.Organizer.Remove(organizers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizersExists(int id)
        {
            return _context.Organizer.Any(e => e.OrganizerInfoID == id);
        }
    }
}
