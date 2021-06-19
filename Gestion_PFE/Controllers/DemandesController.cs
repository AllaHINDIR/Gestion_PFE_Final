using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_PFE.Data;
using Gestion_PFE.Models;
using Microsoft.AspNetCore.Identity;

namespace Gestion_PFE.Controllers
{
    public class DemandesController : Controller
    {
        private readonly GestionContext _context;

       
        

        public DemandesController(GestionContext context)
        {
            _context = context;
        }

        // GET: Demandes
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Demandes.Include(d=>d.Etudiant).Include(d=>d.Encadrant).ToListAsync());
        }

        // GET: Demandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // GET: Demandes/Create
        public IActionResult Create()
        {
            List<Encadrant> listEncadrant = new List<Encadrant>();
            listEncadrant = _context.encadrants.ToList();
            ViewBag.listofitems = listEncadrant;

            List<Etudiant> listEtudiant = new List<Etudiant>();
            listEtudiant = _context.etudiants.ToList();
            ViewBag.data = listEtudiant;

            ViewData["EtudiantID"] = new SelectList(_context.etudiants, "ID", "FullName");
            ViewData["EncadrantID"] = new SelectList(_context.encadrants, "ID", "FullName");

            return View();
        }

        // POST: Demandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,titre,EncadrantID,EtudiantID")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantID"] = new SelectList(_context.etudiants, "ID", "FullName", demande.EtudiantID);
            ViewData["EncadrantID"] = new SelectList(_context.etudiants, "ID", "FullName", demande.EncadrantID);
            return View(demande);
        }

        // GET: Demandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes.FindAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            return View(demande);
        }

        // POST: Demandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Demande demande)
        {
            if (id != demande.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeExists(demande.ID))
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
            return View(demande);
        }

        // GET: Demandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // POST: Demandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);
            _context.Demandes.Remove(demande);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeExists(int id)
        {
            return _context.Demandes.Any(e => e.ID == id);
        }
       
    }
}
