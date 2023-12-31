﻿using EchelonEnforcers.Data;
using EchelonEnforcers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EchelonEnforcers.Controllers
{
    [Authorize]
    public class CompetitionsModelsController : Controller
    {
        private readonly CompetitionsDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CompetitionsModelsController(CompetitionsDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CompetitionsModel
        public async Task<IActionResult> Index()
        {
              return _context.CompetitionsModel != null ? 
                          View(await _context.CompetitionsModel.ToListAsync()) :
                          Problem("Entity set 'CompetitionsDbContext.Competitions'  is null.");
        }

        // GET: CompetitionsModel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CompetitionsModel == null)
            {
                return NotFound();
            }

            var competitions = await _context.CompetitionsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competitions == null)
            {
                return NotFound();
            }

            return View(competitions);
        }

        // GET: CompetitionsModels/Create
        public IActionResult Create()
        {
            var competitionsModel = new CompetitionsModel();

            // Get the current logged-in user
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Set the Author property to the username (you can change this based on your user model)
            competitionsModel.Author = currentUser.UserName;

            return View(competitionsModel);
        }

        // POST: CompetitionsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CompetitionsModel competitions)
        {
            if (ModelState.IsValid)
            {
                competitions.PublishedDate = DateTimeOffset.Now;
                competitions.Id = Guid.NewGuid();
                _context.Add(competitions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competitions);
        }

        // GET: CompetitionsModel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CompetitionsModel == null)
            {
                return NotFound();
            }

            var competitions = await _context.CompetitionsModel.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Content,PublishedDate,Author")] CompetitionsModel competitions)
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
            if (id == null || _context.CompetitionsModel == null)
            {
                return NotFound();
            }

            var competitions = await _context.CompetitionsModel
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
            if (_context.CompetitionsModel == null)
            {
                return Problem("Entity set 'CompetitionsDbContext.Competitions'  is null.");
            }
            var competitions = await _context.CompetitionsModel.FindAsync(id);
            if (competitions != null)
            {
                _context.CompetitionsModel.Remove(competitions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionsExists(Guid id)
        {
          return (_context.CompetitionsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
