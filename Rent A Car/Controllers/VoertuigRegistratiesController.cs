using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car.Models;

namespace Rent_A_Car.Controllers
{
    public class VoertuigRegistratieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoertuigRegistratieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VoertuigRegistraties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VoertuigRegistratie.Include(v => v.ApplicationUser);
            return View(await _context.VoertuigRegistratie.ToListAsync());
        }

        // GET: VoertuigRegistraties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigRegistratie = await _context.VoertuigRegistratie
                 .Include(v => v.ApplicationUser)
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuigRegistratie == null)
            {
                return NotFound();
            }

            return View(voertuigRegistratie);
        }

        // GET: VoertuigRegistraties/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: VoertuigRegistraties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoertuigId,MedewerkerId,Merk,Dagprijs,Type,Kenteken,Schakelaar,Brandstof,ApplicationUserId,TotalePrijs,AantalZitPlaats,Airco,AantalDeur,ApplicationUser,BeginDatum,AantalDagen")] VoertuigRegistratie voertuigRegistratie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voertuigRegistratie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", voertuigRegistratie.ApplicationUserId);
            return View(voertuigRegistratie);
        }

        // GET: VoertuigRegistraties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigRegistratie = await _context.VoertuigRegistratie.FindAsync(id);
            if (voertuigRegistratie == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", voertuigRegistratie.ApplicationUserId);
            return View(voertuigRegistratie);
        }

        // POST: VoertuigRegistraties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoertuigId,MedewerkerId,Merk,Dagprijs,Type,Kenteken,Schakelaar,Brandstof,ApplicationUserId,TotalePrijs,AantalZitPlaats,Airco,AantalDeur,ApplicationUser,BeginDatum,AantalDagen")] VoertuigRegistratie voertuigRegistratie)
        {
            if (id != voertuigRegistratie.VoertuigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voertuigRegistratie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoertuigRegistratieExists(voertuigRegistratie.VoertuigId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", voertuigRegistratie.ApplicationUserId);
            return View(voertuigRegistratie);
        }

        // GET: VoertuigRegistraties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigRegistratie = await _context.VoertuigRegistratie
                  .Include(v => v.ApplicationUser)
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuigRegistratie == null)
            {
                return NotFound();
            }

            return View(voertuigRegistratie);
        }

        // POST: VoertuigRegistraties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voertuigRegistratie = await _context.VoertuigRegistratie.FindAsync(id);
            _context.VoertuigRegistratie.Remove(voertuigRegistratie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigRegistratieExists(int id)
        {
            return _context.VoertuigRegistratie.Any(e => e.VoertuigId == id);
        }
        public async Task<IActionResult> Factuur(string id)
        {
            var applicationDbContext = _context.VoertuigRegistratie.Include(v => v.ApplicationUser);
       
         
            return View(await applicationDbContext.ToListAsync());

        }
     
    }
}
