using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KisKonyvtarNyilvantartas01.Data;
using KisKonyvtarNyilvantartas01.Models;
using Microsoft.AspNetCore.Authorization;

namespace KisKonyvtarNyilvantartas01.Controllers
{
    public class KonyvtarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KonyvtarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Konyvtar
        public async Task<IActionResult> Index(string Cim, string Szerzo, string Mufaj)
        {
            var model = new KonyvKeres();

            var konyv = _context.Konyvek.Select(x => x);

            if (!string.IsNullOrEmpty(Cim))
            {
                model.Cim = Cim;
                konyv = konyv.Where(x => x.Cim == Cim);
            }
            
            if (!string.IsNullOrEmpty(Szerzo))
            {
                model.Szerzo = Szerzo;
                konyv = konyv.Where(x => x.Szerzo.Contains(Szerzo));
            }
            
            if (!string.IsNullOrEmpty(Mufaj))
            {
                model.Mufaj = Mufaj;
                konyv = konyv.Where(x => x.Mufaj == Mufaj);
            }

            model.KonyvLista = await konyv.OrderBy(x => x.Szerzo).ToListAsync();
            model.CimLista = new SelectList(await _context.Konyvek.Select(x => x.Cim).Distinct().OrderBy(x => x).ToListAsync());
            model.CimLista = new SelectList(await _context.Konyvek.Select(x => x.Mufaj).Distinct().OrderBy(x => x).ToListAsync());

            return View(model);
        }

        // GET: Konyvtar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konyvek = await _context.Konyvek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konyvek == null)
            {
                return NotFound();
            }

            return View(konyvek);
        }

        // GET: Konyvtar/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konyvtar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Cim,Szerzo,Mufaj,Ar")] Konyvek konyvek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konyvek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konyvek);
        }

        // GET: Konyvtar/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konyvek = await _context.Konyvek.FindAsync(id);
            if (konyvek == null)
            {
                return NotFound();
            }
            return View(konyvek);
        }

        // POST: Konyvtar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cim,Szerzo,Mufaj,Ar")] Konyvek konyvek)
        {
            if (id != konyvek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konyvek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonyvekExists(konyvek.Id))
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
            return View(konyvek);
        }

        // GET: Konyvtar/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konyvek = await _context.Konyvek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konyvek == null)
            {
                return NotFound();
            }

            return View(konyvek);
        }

        // POST: Konyvtar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konyvek = await _context.Konyvek.FindAsync(id);
            _context.Konyvek.Remove(konyvek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonyvekExists(int id)
        {
            return _context.Konyvek.Any(e => e.Id == id);
        }
    }
}
