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
    public class DeleteModel : PageModel
    {
        private readonly PlatformyProgramistyczneAPI.F1Api.DriversDatabase _context;

        public DeleteModel(PlatformyProgramistyczneAPI.F1Api.DriversDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public SessionDb SessionDb { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessiondb = await _context.Sessions.FirstOrDefaultAsync(m => m.id == id);

            if (sessiondb == null)
            {
                return NotFound();
            }
            else
            {
                SessionDb = sessiondb;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessiondb = await _context.Sessions.FindAsync(id);
            if (sessiondb != null)
            {
                SessionDb = sessiondb;
                _context.Sessions.Remove(SessionDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
