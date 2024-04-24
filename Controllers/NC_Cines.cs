using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicolasCasamen_Examen1P.Data;
using NicolasCasamen_Examen1P.Models;

namespace NicolasCasamen_Examen1P.Controllers
{
    public class NC_Cines : Controller
    {
        private readonly NicolasCasamen_Examen1PContext _context;

        public NC_Cines(NicolasCasamen_Examen1PContext context)
        {
            _context = context;
        }

        // GET: NC_Cines
        public async Task<IActionResult> Index()
        {
              return _context.NC_Cine != null ? 
                          View(await _context.NC_Cine.ToListAsync()) :
                          Problem("Entity set 'NicolasCasamen_Examen1PContext.NC_Cine'  is null.");
        }

        // GET: NC_Cines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NC_Cine == null)
            {
                return NotFound();
            }

            var nC_Cine = await _context.NC_Cine
                .FirstOrDefaultAsync(m => m.NC_NumeroBoleto == id);
            if (nC_Cine == null)
            {
                return NotFound();
            }

            return View(nC_Cine);
        }

        // GET: NC_Cines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NC_Cines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NC_NumeroBoleto,NC_Pelicula,NC_FechaPelicula,NC_Entradas,NC_Socio,NC_Costo")] NC_Cine nC_Cine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nC_Cine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nC_Cine);
        }

        // GET: NC_Cines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NC_Cine == null)
            {
                return NotFound();
            }

            var nC_Cine = await _context.NC_Cine.FindAsync(id);
            if (nC_Cine == null)
            {
                return NotFound();
            }
            return View(nC_Cine);
        }

        // POST: NC_Cines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NC_NumeroBoleto,NC_Pelicula,NC_FechaPelicula,NC_Entradas,NC_Socio,NC_Costo")] NC_Cine nC_Cine)
        {
            if (id != nC_Cine.NC_NumeroBoleto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nC_Cine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NC_CineExists(nC_Cine.NC_NumeroBoleto))
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
            return View(nC_Cine);
        }

        // GET: NC_Cines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NC_Cine == null)
            {
                return NotFound();
            }

            var nC_Cine = await _context.NC_Cine
                .FirstOrDefaultAsync(m => m.NC_NumeroBoleto == id);
            if (nC_Cine == null)
            {
                return NotFound();
            }

            return View(nC_Cine);
        }

        // POST: NC_Cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NC_Cine == null)
            {
                return Problem("Entity set 'NicolasCasamen_Examen1PContext.NC_Cine'  is null.");
            }
            var nC_Cine = await _context.NC_Cine.FindAsync(id);
            if (nC_Cine != null)
            {
                _context.NC_Cine.Remove(nC_Cine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NC_CineExists(int id)
        {
          return (_context.NC_Cine?.Any(e => e.NC_NumeroBoleto == id)).GetValueOrDefault();
        }
    }
}
