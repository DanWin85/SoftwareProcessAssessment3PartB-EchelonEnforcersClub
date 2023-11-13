using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Data;
using EchelonEnforcers.Models;
using Microsoft.AspNetCore.Authorization;

namespace EchelonEnforcers.Controllers
{
    public class CompetitionsModelsController : Controller
    {
        private readonly CompetitionsDbContext _context;

        public CompetitionsModelsController(CompetitionsDbContext context)
        {
            _context = context;
        }

        // GET: CompetitionsModel
        public async Task<IActionResult> Index()
        {
              return _context.Competitions != null ? 
                          View(await _context.Competitions.ToListAsync()) :
                          Problem("Entity set 'CompetitionsDbContext.Competitions'  is null.");
        }

        // GET: CompetitionsModel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Competitions == null)
            {
                return NotFound();
            }

            var competitions = await _context.Competitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competitions == null)
            {
                return NotFound();
            }

            return View(competitions);
        }

        // GET: CompetitionsModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetitionsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,PublishedDate,Author")] Competitions competitions)
        {
            if (ModelState.IsValid)
            {
                competitions.Id = Guid.NewGuid();
                //competitions.Author = User.Identity.Name;
                _context.Add(competitions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competitions);
        }

        // GET: CompetitionsModel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Competitions == null)
            {
                return NotFound();
            }

            var competitions = await _context.Competitions.FindAsync(id);
            if (competitions == null)
            {
                return NotFound();
            }
            return View(competitions);
        }

        // POST: CompetitionsModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Content,PublishedDate,Author")] Competitions competitions)
        {
            if (id != competitions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competitions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionsExists(competitions.Id))
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
            return View(competitions);
        }

        // GET: CompetitionsModel/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Competitions == null)
            {
                return NotFound();
            }

            var competitions = await _context.Competitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competitions == null)
            {
                return NotFound();
            }

            return View(competitions);
        }

        // POST: CompetitionsModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Competitions == null)
            {
                return Problem("Entity set 'CompetitionsDbContext.Competitions'  is null.");
            }
            var competitions = await _context.Competitions.FindAsync(id);
            if (competitions != null)
            {
                _context.Competitions.Remove(competitions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionsExists(Guid id)
        {
          return (_context.Competitions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
