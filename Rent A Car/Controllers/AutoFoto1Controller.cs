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
    public class AutoFoto1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoFoto1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AutoFoto1
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutoFoto1s.ToListAsync());
        }

        // GET: AutoFoto1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoFoto1 = await _context.AutoFoto1s
                .FirstOrDefaultAsync(m => m.Bestandsnaam == id);
            if (autoFoto1 == null)
            {
                return NotFound();
            }

            return View(autoFoto1);
        }

        // GET: AutoFoto1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoFoto1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bestandsnaam,Foto")] AutoFoto1 autoFoto1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoFoto1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoFoto1);
        }

        // GET: AutoFoto1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoFoto1 = await _context.AutoFoto1s.FindAsync(id);
            if (autoFoto1 == null)
            {
                return NotFound();
            }
            return View(autoFoto1);
        }

        // POST: AutoFoto1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Bestandsnaam,Foto")] AutoFoto1 autoFoto1)
        {
            if (id != autoFoto1.Bestandsnaam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoFoto1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoFoto1Exists(autoFoto1.Bestandsnaam))
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
            return View(autoFoto1);
        }

        // GET: AutoFoto1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoFoto1 = await _context.AutoFoto1s
                .FirstOrDefaultAsync(m => m.Bestandsnaam == id);
            if (autoFoto1 == null)
            {
                return NotFound();
            }

            return View(autoFoto1);
        }

        // POST: AutoFoto1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var autoFoto1 = await _context.AutoFoto1s.FindAsync(id);
            _context.AutoFoto1s.Remove(autoFoto1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoFoto1Exists(string id)
        {
            return _context.AutoFoto1s.Any(e => e.Bestandsnaam == id);
        }
    }
}
