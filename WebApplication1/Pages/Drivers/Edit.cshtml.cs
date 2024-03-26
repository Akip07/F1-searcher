using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatformyProgramistyczneAPI.F1Api;

namespace WebApplication1.Pages.Drivers
{
    public class EditModel : PageModel
    {
        private readonly PlatformyProgramistyczneAPI.F1Api.DriversDatabase _context;

        public EditModel(PlatformyProgramistyczneAPI.F1Api.DriversDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public DriverDb DriverDb { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverdb =  await _context.Drivers.FirstOrDefaultAsync(m => m.id == id);
            if (driverdb == null)
            {
                return NotFound();
            }
            DriverDb = driverdb;
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

            _context.Attach(DriverDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverDbExists(DriverDb.id))
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

        private bool DriverDbExists(int id)
        {
            return _context.Drivers.Any(e => e.id == id);
        }
    }
}
