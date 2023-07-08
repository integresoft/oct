using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MainstreamDOCSdotweb.Data;
using Microsoft.AspNetCore.Authorization;

namespace MainstreamDOCSdotweb.Pages.Docs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext _context;

        public CreateModel(MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Properties Properties { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Properties == null || Properties == null)
            {
                return Page();
            }

            _context.Properties.Add(Properties);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
