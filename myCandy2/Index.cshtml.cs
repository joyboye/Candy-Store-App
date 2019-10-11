using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candy_Store_App2.Data;

namespace Candy_Store_App2.Pages.myCandy2
{
    public class IndexModel : PageModel
    {
        private readonly Candy_Store_App2.Data.ApplicationDbContext _context;

        public IndexModel(Candy_Store_App2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Candy> Candy { get;set; }

        public async Task OnGetAsync()
        {
            Candy = await _context.Candy
                .Include(c => c.Manufactures)
                .Include(c => c.Stores).ToListAsync();
        }
    }
}
