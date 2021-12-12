using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car.Models;
using Rent_A_Car.Models.Autos;

namespace Rent_A_Car.Controllers
{
    public class Auto1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;

        public Auto1Controller(ApplicationDbContext context , IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        // GET: Auto1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auto1s.ToListAsync());
        }

        // GET: Auto1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto1 = await _context.Auto1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto1 == null)
            {
                return NotFound();
            }

            return View(auto1);
        }

        // GET: Auto1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auto1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Voornaam,Achternaam")] Auto1 auto1)
        {
            if (ModelState.IsValid)

            {

                var inputFile = Request.Form.Files["inputFile"];

                using (var ms = new MemoryStream())

                {

                    await inputFile.CopyToAsync(ms);

                    var fileBytes = ms.ToArray();

                    auto1.AutoAfbeelding = new AutoFoto1()

                    {

                        Foto = fileBytes,

                        Bestandsnaam = auto1.Code,

                        Voertuig = auto1

                    };

                    // act on the Base64 data

                }

                _context.Add(auto1.AutoAfbeelding);

                _context.Add(auto1);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(auto1);

        }

        // GET: Auto1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto1 = await _context.Auto1s.FindAsync(id);
            if (auto1 == null)
            {
                return NotFound();
            }
            return View(auto1);
        }

        // POST: Auto1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Voornaam,Achternaam")] Auto1 auto1)
        {
            if (id != auto1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Auto1Exists(auto1.Id))
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
            return View(auto1);
        }

        // GET: Auto1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto1 = await _context.Auto1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto1 == null)
            {
                return NotFound();
            }

            return View(auto1);
        }

        // POST: Auto1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto1 = await _context.Auto1s.FindAsync(id);
            _context.Auto1s.Remove(auto1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Auto1Exists(int id)
        {
            return _context.Auto1s.Any(e => e.Id == id);
        }
    }
}
