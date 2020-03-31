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
    public class Categoria_VueloController : Controller
    {
        private readonly AerolineaContext _context;

        public Categoria_VueloController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: Categoria_Vuelo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria_Vuelo.ToListAsync());
        }

        // GET: Categoria_Vuelo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Vuelo = await _context.Categoria_Vuelo
                .FirstOrDefaultAsync(m => m.SerieAvion == id);
            if (categoria_Vuelo == null)
            {
                return NotFound();
            }

            return View(categoria_Vuelo);
        }

        // GET: Categoria_Vuelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Vuelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerieAvion,Cliente,Destino,Entrada,Salida")] Categoria_Vuelo categoria_Vuelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria_Vuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria_Vuelo);
        }

        // GET: Categoria_Vuelo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Vuelo = await _context.Categoria_Vuelo.FindAsync(id);
            if (categoria_Vuelo == null)
            {
                return NotFound();
            }
            return View(categoria_Vuelo);
        }

        // POST: Categoria_Vuelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SerieAvion,Cliente,Destino,Entrada,Salida")] Categoria_Vuelo categoria_Vuelo)
        {
            if (id != categoria_Vuelo.SerieAvion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria_Vuelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoria_VueloExists(categoria_Vuelo.SerieAvion))
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
            return View(categoria_Vuelo);
        }

        // GET: Categoria_Vuelo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Vuelo = await _context.Categoria_Vuelo
                .FirstOrDefaultAsync(m => m.SerieAvion == id);
            if (categoria_Vuelo == null)
            {
                return NotFound();
            }

            return View(categoria_Vuelo);
        }

        // POST: Categoria_Vuelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var categoria_Vuelo = await _context.Categoria_Vuelo.FindAsync(id);
            _context.Categoria_Vuelo.Remove(categoria_Vuelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoria_VueloExists(string id)
        {
            return _context.Categoria_Vuelo.Any(e => e.SerieAvion == id);
        }
    }
}
