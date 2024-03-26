using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformyProgramistyczneAPI;
using PlatformyProgramistyczneAPI.F1Api;

namespace WebApplication1.Pages.Drivers
{
    public class IndexModel : PageModel
    {
        private readonly PlatformyProgramistyczneAPI.F1Api.DriversDatabase _context;

        public IndexModel(PlatformyProgramistyczneAPI.F1Api.DriversDatabase context)
        {
            _context = context;
        }

        public IList<DriverDb> DriverDb { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    DriverDb = await _context.Drivers.ToListAsync();
        //}

        public async Task OnGetAsync(int key=0)
        {
            if(key==0)
                DriverDb = await _context.Drivers.ToListAsync();
            else
            {
                DbManager run = new DbManager();
                run.DriversFromSession(key);
                DriverDb = await _context.Drivers.Where(d => d.session_key == key).ToListAsync();
            }
            
        }
    }
}
