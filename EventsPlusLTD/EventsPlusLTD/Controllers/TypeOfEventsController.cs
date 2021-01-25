﻿using System;
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
    public class TypeOfEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeOfEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeOfEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfEvent.ToListAsync());
        }

        // GET: TypeOfEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfEvent = await _context.TypeOfEvent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typeOfEvent == null)
            {
                return NotFound();
            }

            return View(typeOfEvent);
        }

        // GET: TypeOfEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Event_Type")] TypeOfEvent typeOfEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfEvent);
        }

        // GET: TypeOfEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfEvent = await _context.TypeOfEvent.FindAsync(id);
            if (typeOfEvent == null)
            {
                return NotFound();
            }
            return View(typeOfEvent);
        }

        // POST: TypeOfEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Event_Type")] TypeOfEvent typeOfEvent)
        {
            if (id != typeOfEvent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfEventExists(typeOfEvent.ID))
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
            return View(typeOfEvent);
        }

        // GET: TypeOfEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfEvent = await _context.TypeOfEvent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typeOfEvent == null)
            {
                return NotFound();
            }

            return View(typeOfEvent);
        }

        // POST: TypeOfEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfEvent = await _context.TypeOfEvent.FindAsync(id);
            _context.TypeOfEvent.Remove(typeOfEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfEventExists(int id)
        {
            return _context.TypeOfEvent.Any(e => e.ID == id);
        }
    }
}
