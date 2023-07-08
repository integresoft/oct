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
    public class DetailsModel : PageModel
    {
        private readonly MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext _context;

        public DetailsModel(MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext context)
        {
            _context = context;
        }

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
    }
}
