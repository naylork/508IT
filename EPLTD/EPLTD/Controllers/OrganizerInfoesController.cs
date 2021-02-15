using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPLTD.Data;
using EPLTD.Models;
using Microsoft.AspNetCore.Authorization;

namespace EPLTD.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrganizerInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizerInfoes
        public async Task<IActionResult> Index_Default()
        {
            var applicationDbContext = _context.OrganizerInfo.Include(e => e.Organizer);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["FirstNameSort"] = String.IsNullOrEmpty(sortOrder) ? "FirstName_Desc" : "";
            ViewData["LastNameSort"] = sortOrder == "LastName_Asc" ? "LastName_Desc" : "LastName_Asc";
            ViewData["ContactEmailSort"] = sortOrder == "ContactEmail_Asc" ? "ContactEmail_Desc" : "ContactEmail_Asc";
            var organizerInfo = from f in _context.OrganizerInfo.Include(f => f.Organizer)
                                select f;

            /** Sorting Script **/
            switch (sortOrder)
            {
                case "FirstName_Desc":
                    organizerInfo = organizerInfo.OrderByDescending(f => f.FirstName);
                    break;
                case "LastName_Asc":
                    organizerInfo = organizerInfo.OrderBy(f => f.LastName);
                    break;
                case "LastName_Desc":
                    organizerInfo = organizerInfo.OrderByDescending(f => f.LastName);
                    break;
                case "ContactEmail_Asc":
                    organizerInfo = organizerInfo.OrderBy(f => f.ContactEmail);
                    break;
                case "ContactEmail_Desc":
                    organizerInfo = organizerInfo.OrderByDescending(f => f.ContactEmail);
                    break;


                default:
                    organizerInfo = organizerInfo.OrderBy(f => f.FirstName);
                    break;

            }

            /*** Search Script ****/
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                organizerInfo = organizerInfo.Where(f => f.FirstName.Contains(searchString)
                    || f.LastName.Contains(searchString)
                        || f.ContactEmail.Contains(searchString));

            }

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 3;
            return View(await PaginatedList<OrganizerInfo>.CreateAsync(organizerInfo.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: OrganizerInfoes/Details/5
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
        public async Task<IActionResult> Create([Bind("OrganizerInfoID,FirstName,LastName,ContactEmail,ContactNumber")] OrganizerInfo organizerInfo)
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
        public async Task<IActionResult> Edit(int id, [Bind("OrganizerInfoID,FirstName,LastName,ContactEmail,ContactNumber")] OrganizerInfo organizerInfo)
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

        // GET: OrganizerInfoes/Delete/5
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
            return _context.OrganizerInfo.Any(e => e.OrganizerInfoID == id);
        }
    }
}
