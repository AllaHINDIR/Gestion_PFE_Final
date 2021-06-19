using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_PFE.Data;
using Gestion_PFE.Models;

namespace Gestion_PFE.Controllers
{
    public class EncadrantsController : Controller
    {
        private readonly GestionContext _context;

        public EncadrantsController(GestionContext context)
        {
            _context = context;
        }

        // GET: Encadrants
        public async Task<IActionResult> Index()
        {
            return View(await _context.encadrants.ToListAsync());
        }

        // GET: Encadrants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encadrant = await _context.encadrants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (encadrant == null)
            {
                return NotFound();
            }

            return View(encadrant);
        }

        // GET: Encadrants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encadrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName")] Encadrant encadrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encadrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encadrant);
        }

        // GET: Encadrants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encadrant = await _context.encadrants.FindAsync(id);
            if (encadrant == null)
            {
                return NotFound();
            }
            return View(encadrant);
        }

        // POST: Encadrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName")] Encadrant encadrant)
        {
            if (id != encadrant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encadrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncadrantExists(encadrant.ID))
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
            return View(encadrant);
        }

        // GET: Encadrants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encadrant = await _context.encadrants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (encadrant == null)
            {
                return NotFound();
            }

            return View(encadrant);
        }

        // POST: Encadrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encadrant = await _context.encadrants.FindAsync(id);
            _context.encadrants.Remove(encadrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncadrantExists(int id)
        {
            return _context.encadrants.Any(e => e.ID == id);
        }
    }
}
