using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EchelonEnforcers.Data;
using EchelonEnforcers.Models;

namespace EchelonEnforcers.Pages
{
    public class CompetitionsModel : PageModel
    {
        private readonly EchelonEnforcers.Data.CompetitionsDbContext _context;

        public CompetitionsModel(EchelonEnforcers.Data.CompetitionsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Competitions Competitions { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Competitions == null || Competitions == null)
            {
                return Page();
            }

            _context.Competitions.Add(Competitions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
