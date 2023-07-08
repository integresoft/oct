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
    public class IndexModel : PageModel
    {
        private readonly MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext _context;

        public IndexModel(MainstreamDOCSdotweb.Data.MainstreamDOCSdotwebContext context)
        {
            _context = context;
        }

        public IList<Properties> Properties { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Properties != null)
            {
                Properties = await _context.Properties.ToListAsync();
            }
        }
    }
}
