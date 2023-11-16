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
    [Authorize]
    public class NewsModelsController : Controller
    {
        private readonly NewsDbContext _context;

        public NewsModelsController(NewsDbContext context)
        {
            _context = context;
        }

        // GET: NewsModels
        public async Task<IActionResult> Index()
        {
              return _context.NewsModel != null ? 
                          View(await _context.NewsModel.ToListAsync()) :
                          Problem("Entity set 'NewsDbContext.NewsModel'  is null.");
        }

        // GET: NewsModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }

        // GET: NewsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,Content,PublishedDate,Author,Visible")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                newsModel.Id = Guid.NewGuid();
                _context.Add(newsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsModel);
        }

        // GET: NewsModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel.FindAsync(id);
            if (newsModel == null)
            {
                return NotFound();
            }
            return View(newsModel);
        }

        // POST: NewsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Heading,Content,PublishedDate,Author,Visible")] NewsModel newsModel)
        {
            if (id != newsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsModelExists(newsModel.Id))
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
            return View(newsModel);
        }

        // GET: NewsModels/Delete/5
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }

        // POST: NewsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NewsModel == null)
            {
                return Problem("Entity set 'NewsDbContext.NewsModel'  is null.");
            }
            var newsModel = await _context.NewsModel.FindAsync(id);
            if (newsModel != null)
            {
                _context.NewsModel.Remove(newsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsModelExists(Guid id)
        {
          return (_context.NewsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
