using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candy_Store_App2.Data;

namespace Candy_Store_App2.Pages.myCandy2
{
    public class EditModel : PageModel
    {
        private readonly Candy_Store_App2.Data.ApplicationDbContext _context;

        public EditModel(Candy_Store_App2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candy = await _context.Candy
                .Include(c => c.Manufactures)
                .Include(c => c.Stores).FirstOrDefaultAsync(m => m.CandyId == id);

            if (Candy == null)
            {
                return NotFound();
            }
           ViewData["MID"] = new SelectList(_context.Set<Manufacturer>(), "MId", "MId");
           ViewData["StoreId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandyExists(Candy.CandyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandyExists(int id)
        {
            return _context.Candy.Any(e => e.CandyId == id);
        }
    }
}
