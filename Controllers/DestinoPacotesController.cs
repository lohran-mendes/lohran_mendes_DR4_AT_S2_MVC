using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lohran_mendes_DR4_AT_S2.DAL;
using lohran_mendes_DR4_AT_S2.Models;

namespace lohran_mendes_DR4_AT_S2.Controllers
{
    public class DestinoPacotesController : Controller
    {
        private readonly Contexto _context;

        public DestinoPacotesController(Contexto context)
        {
            _context = context;
        }

        // GET: DestinoPacotes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.DestinosPacotes.Include(d => d.Destino).Include(d => d.PacoteTuristico);
            return View(await contexto.ToListAsync());
        }

        // GET: DestinoPacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinosPacotes = await _context.DestinosPacotes
                .Include(d => d.Destino)
                .Include(d => d.PacoteTuristico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (destinosPacotes == null)
            {
                return NotFound();
            }

            return View(destinosPacotes);
        }

        // GET: DestinoPacotes/Create
        public IActionResult Create()
        {
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome");
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
            return View();
        }

        // POST: DestinoPacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DestinoId,PacoteTuristicoId")] DestinosPacotes destinosPacotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinosPacotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome", destinosPacotes.DestinoId);
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo", destinosPacotes.PacoteTuristicoId);
            return View(destinosPacotes);
        }

        // GET: DestinoPacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinosPacotes = await _context.DestinosPacotes.FindAsync(id);
            if (destinosPacotes == null)
            {
                return NotFound();
            }
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome", destinosPacotes.DestinoId);
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo", destinosPacotes.PacoteTuristicoId);
            return View(destinosPacotes);
        }

        // POST: DestinoPacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DestinoId,PacoteTuristicoId")] DestinosPacotes destinosPacotes)
        {
            if (id != destinosPacotes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinosPacotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinosPacotesExists(destinosPacotes.id))
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
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome", destinosPacotes.DestinoId);
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo", destinosPacotes.PacoteTuristicoId);
            return View(destinosPacotes);
        }

        // GET: DestinoPacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinosPacotes = await _context.DestinosPacotes
                .Include(d => d.Destino)
                .Include(d => d.PacoteTuristico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (destinosPacotes == null)
            {
                return NotFound();
            }

            return View(destinosPacotes);
        }

        // POST: DestinoPacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinosPacotes = await _context.DestinosPacotes.FindAsync(id);
            if (destinosPacotes != null)
            {
                _context.DestinosPacotes.Remove(destinosPacotes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinosPacotesExists(int id)
        {
            return _context.DestinosPacotes.Any(e => e.id == id);
        }
    }
}
