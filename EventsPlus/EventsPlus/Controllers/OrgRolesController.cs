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
    public class OrgRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrgRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrgRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizerRole.ToListAsync());
        }

        // GET: OrgRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRole = await _context.OrganizerRole
                .FirstOrDefaultAsync(m => m.OrganizerRoleID == id);
            if (orgRole == null)
            {
                return NotFound();
            }

            return View(orgRole);
        }

        // GET: OrgRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrgRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizerRoleID,RoleName")] OrgRole orgRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orgRole);
        }

        // GET: OrgRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRole = await _context.OrganizerRole.FindAsync(id);
            if (orgRole == null)
            {
                return NotFound();
            }
            return View(orgRole);
        }

        // POST: OrgRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerRoleID,RoleName")] OrgRole orgRole)
        {
            if (id != orgRole.OrganizerRoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgRoleExists(orgRole.OrganizerRoleID))
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
            return View(orgRole);
        }

        // GET: OrgRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRole = await _context.OrganizerRole
                .FirstOrDefaultAsync(m => m.OrganizerRoleID == id);
            if (orgRole == null)
            {
                return NotFound();
            }

            return View(orgRole);
        }

        // POST: OrgRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgRole = await _context.OrganizerRole.FindAsync(id);
            _context.OrganizerRole.Remove(orgRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgRoleExists(int id)
        {
            return _context.OrganizerRole.Any(e => e.OrganizerRoleID == id);
        }
    }
}
