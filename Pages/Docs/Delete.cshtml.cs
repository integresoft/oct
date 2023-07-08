using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MainstreamDOCSdotweb.Data;
using Microsoft.AspNetCore.Authorization;

namespace MainstreamDOCSdotweb.Pages.Docs
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext _context;

        public DeleteModel(MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Properties Properties { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Properties == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);

            if (properties == null)
            {
                return NotFound();
            }
            else 
            {
                Properties = properties;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Properties == null)
            {
                return NotFound();
            }
            var properties = await _context.Properties.FindAsync(id);

            if (properties != null)
            {
                Properties = properties;
                _context.Properties.Remove(Properties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
