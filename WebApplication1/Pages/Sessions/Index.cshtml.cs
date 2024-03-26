using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformyProgramistyczneAPI.F1Api;

namespace WebApplication1.Pages.Sessions
{
    public class IndexModel : PageModel
    {
        private readonly PlatformyProgramistyczneAPI.F1Api.DriversDatabase _context;

        public IndexModel(PlatformyProgramistyczneAPI.F1Api.DriversDatabase context)
        {
            _context = context;
        }

        public IList<SessionDb> SessionDb { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SessionDb = await _context.Sessions.ToListAsync();
        }
    }
}
