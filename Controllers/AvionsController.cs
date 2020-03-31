using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aerolinea.Models;

namespace Aerolinea.Controllers
{
    public class AvionsController : Controller
    {
        private readonly AerolineaContext _context;

        public AvionsController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: Avions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avion.ToListAsync());
        }

        // GET: Avions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avion = await _context.Avion
                .FirstOrDefaultAsync(m => m.Serie == id);
            if (avion == null)
            {
                return NotFound();
            }

            return View(avion);
        }

        // GET: Avions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Serie,Nombre,Fabricante,Activo,Inactivo")] Avion avion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avion);
        }

        // GET: Avions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avion = await _context.Avion.FindAsync(id);
            if (avion == null)
            {
                return NotFound();
            }
            return View(avion);
        }

        // POST: Avions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Serie,Nombre,Fabricante,Activo,Inactivo")] Avion avion)
        {
            if (id != avion.Serie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvionExists(avion.Serie))
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
            return View(avion);
        }

        // GET: Avions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avion = await _context.Avion
                .FirstOrDefaultAsync(m => m.Serie == id);
            if (avion == null)
            {
                return NotFound();
            }

            return View(avion);
        }

        // POST: Avions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var avion = await _context.Avion.FindAsync(id);
            _context.Avion.Remove(avion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvionExists(string id)
        {
            return _context.Avion.Any(e => e.Serie == id);
        }
    }
}
