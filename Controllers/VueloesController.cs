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
    public class VueloesController : Controller
    {
        private readonly AerolineaContext _context;

        public VueloesController(AerolineaContext context)
        {
            _context = context;
        }

        // GET: Vueloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vuelo.ToListAsync());
        }

        // GET: Vueloes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelo
                .FirstOrDefaultAsync(m => m.IdVuelo == id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return View(vuelo);
        }

        // GET: Vueloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vueloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVuelo,Nombre_Vuelo,Fecha_Salida,Fecha_Entrada,Origen,Destino")] Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vuelo);
        }

        // GET: Vueloes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelo.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }
            return View(vuelo);
        }

        // POST: Vueloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdVuelo,Nombre_Vuelo,Fecha_Salida,Fecha_Entrada,Origen,Destino")] Vuelo vuelo)
        {
            if (id != vuelo.IdVuelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vuelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueloExists(vuelo.IdVuelo))
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
            return View(vuelo);
        }

        // GET: Vueloes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelo
                .FirstOrDefaultAsync(m => m.IdVuelo == id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return View(vuelo);
        }

        // POST: Vueloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vuelo = await _context.Vuelo.FindAsync(id);
            _context.Vuelo.Remove(vuelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueloExists(string id)
        {
            return _context.Vuelo.Any(e => e.IdVuelo == id);
        }
    }
}
