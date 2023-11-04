using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CosCumparaturi.Data;
using CosCumparaturi.Models;

namespace CosCumparaturi.Controllers
{
    public class ProdusesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produses
        public async Task<IActionResult> Index()
        {
              return _context.Cos != null ? 
                          View(await _context.Cos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cos'  is null.");
        }

        // GET: Produses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }

            var produse = await _context.Cos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // GET: Produses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Denumire,Descriere,Canti,Valabilitate")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produse);
        }

        // GET: Produses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }

            var produse = await _context.Cos.FindAsync(id);
            if (produse == null)
            {
                return NotFound();
            }
            return View(produse);
        }

        // POST: Produses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denumire,Descriere,Canti,Valabilitate")] Produse produse)
        {
            if (id != produse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduseExists(produse.Id))
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
            return View(produse);
        }

        // GET: Produses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cos == null)
            {
                return NotFound();
            }

            var produse = await _context.Cos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // POST: Produses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cos'  is null.");
            }
            var produse = await _context.Cos.FindAsync(id);
            if (produse != null)
            {
                _context.Cos.Remove(produse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduseExists(int id)
        {
          return (_context.Cos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
