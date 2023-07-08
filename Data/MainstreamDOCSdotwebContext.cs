using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MainstreamDOCSdotweb.Pages.Docs;

namespace MainstreamDOCSdotweb.Data
{
    public class MainstreamDOCSdotwebContext : DbContext
    {
        public MainstreamDOCSdotwebContext (DbContextOptions<MainstreamDOCSdotwebContext> options)
            : base(options)
        {
        }

        public DbSet<MainstreamDOCSdotweb.Pages.Docs.Properties> Properties { get; set; } = default!;
    }
}
