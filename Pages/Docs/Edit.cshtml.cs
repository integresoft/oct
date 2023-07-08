using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainstreamDOCSdotweb.Data;
using Microsoft.AspNetCore.Authorization;

namespace MainstreamDOCSdotweb.Pages.Docs
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext _context;

        public EditModel(MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext context)
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

            var properties =  await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);
            if (properties == null)
            {
                return NotFound();
            }
            Properties = properties;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Properties).State = EntityState.Unchanged;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertiesExists(Properties.Id))
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

        private bool PropertiesExists(int id)
        {
          return (_context.Properties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
