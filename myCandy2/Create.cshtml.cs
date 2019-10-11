using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candy_Store_App2.Data;

namespace Candy_Store_App2.Pages.myCandy2
{
    public class CreateModel : PageModel
    {
        private readonly Candy_Store_App2.Data.ApplicationDbContext _context;

        public CreateModel(Candy_Store_App2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MID"] = new SelectList(_context.Set<Manufacturer>(), "MId", "MId");
        ViewData["StoreId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId");
            return Page();
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candy.Add(Candy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}