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
    public class VoertuigReservatieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoertuigReservatieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VoertuigReservatie
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoertuigReservatie.ToListAsync());
        }

        // GET: VoertuigReservatie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigReservatie = await _context.VoertuigReservatie
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuigReservatie == null)
            {
                return NotFound();
            }

            return View(voertuigReservatie);
        }

        // GET: VoertuigReservatie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoertuigReservatie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoertuigId,KlantId,AutoType,BeginDatum,EindDatum")] VoertuigReservatie voertuigReservatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voertuigReservatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voertuigReservatie);
        }

        // GET: VoertuigReservatie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigReservatie = await _context.VoertuigReservatie.FindAsync(id);
            if (voertuigReservatie == null)
            {
                return NotFound();
            }
            return View(voertuigReservatie);
        }

        // POST: VoertuigReservatie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoertuigId,KlantId,AutoType,BeginDatum,EindDatum")] VoertuigReservatie voertuigReservatie)
        {
            if (id != voertuigReservatie.VoertuigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voertuigReservatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoertuigReservatieExists(voertuigReservatie.VoertuigId))
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
            return View(voertuigReservatie);
        }

        // GET: VoertuigReservatie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigReservatie = await _context.VoertuigReservatie
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuigReservatie == null)
            {
                return NotFound();
            }

            return View(voertuigReservatie);
        }

        // POST: VoertuigReservatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voertuigReservatie = await _context.VoertuigReservatie.FindAsync(id);
            _context.VoertuigReservatie.Remove(voertuigReservatie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigReservatieExists(int id)
        {
            return _context.VoertuigReservatie.Any(e => e.VoertuigId == id);
        }
    }
}
