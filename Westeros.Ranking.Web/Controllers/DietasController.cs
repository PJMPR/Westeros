using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Views
{
    public class DietasController : Controller
    {
        private readonly StarkDbContext _context;

        public DietasController(StarkDbContext context)
        {
            _context = context;
        }

        // GET: Dietas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DietyOdwiedziny.ToListAsync());
        }

        // GET: Dietas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieta = await _context.DietyOdwiedziny
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dieta == null)
            {
                return NotFound();
            }

            return View(dieta);
        }

        // GET: Dietas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dietas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DietaId,IloscOdwiedzin")] Dieta dieta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dieta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dieta);
        }

        // GET: Dietas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieta = await _context.DietyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);
            if (dieta == null)
            {
                return NotFound();
            }
            return View(dieta);
        }

        // POST: Dietas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DietaId,IloscOdwiedzin")] Dieta dieta)
        {
            if (id != dieta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dieta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietaExists(dieta.Id))
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
            return View(dieta);
        }

        // GET: Dietas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieta = await _context.DietyOdwiedziny
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dieta == null)
            {
                return NotFound();
            }

            return View(dieta);
        }

        // POST: Dietas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dieta = await _context.DietyOdwiedziny.SingleOrDefaultAsync(m => m.Id == id);
            _context.DietyOdwiedziny.Remove(dieta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietaExists(int id)
        {
            return _context.DietyOdwiedziny.Any(e => e.Id == id);
        }
    }
}
