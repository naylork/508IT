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
    public class OrganizerRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizerRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizerRole.ToListAsync());
        }

        // GET: OrganizerRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerRole = await _context.OrganizerRole
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizerRole == null)
            {
                return NotFound();
            }

            return View(organizerRole);
        }

        // GET: OrganizerRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizerRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RoleName")] OrganizerRole organizerRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizerRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizerRole);
        }

        // GET: OrganizerRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerRole = await _context.OrganizerRole.FindAsync(id);
            if (organizerRole == null)
            {
                return NotFound();
            }
            return View(organizerRole);
        }

        // POST: OrganizerRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RoleName")] OrganizerRole organizerRole)
        {
            if (id != organizerRole.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizerRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerRoleExists(organizerRole.ID))
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
            return View(organizerRole);
        }

        // GET: OrganizerRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizerRole = await _context.OrganizerRole
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizerRole == null)
            {
                return NotFound();
            }

            return View(organizerRole);
        }

        // POST: OrganizerRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizerRole = await _context.OrganizerRole.FindAsync(id);
            _context.OrganizerRole.Remove(organizerRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerRoleExists(int id)
        {
            return _context.OrganizerRole.Any(e => e.ID == id);
        }
    }
}
