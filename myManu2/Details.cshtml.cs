using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candy_Store_App2.Data;

namespace Candy_Store_App2.Pages.myManu2
{
    public class DetailsModel : PageModel
    {
        private readonly Candy_Store_App2.Data.ApplicationDbContext _context;

        public DetailsModel(Candy_Store_App2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.MId == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
