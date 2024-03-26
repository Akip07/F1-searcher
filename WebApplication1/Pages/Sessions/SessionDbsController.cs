using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatformyProgramistyczneAPI.F1Api;

namespace WebApplication1.Pages.Sessions
{
    public class SessionDbsController : Controller
    {
        private readonly DriversDatabase _context;

        public SessionDbsController(DriversDatabase context)
        {
            _context = context;
        }

        // GET: SessionDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessions.ToListAsync());
        }

        // GET: SessionDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionDb = await _context.Sessions
                .FirstOrDefaultAsync(m => m.id == id);
            if (sessionDb == null)
            {
                return NotFound();
            }

            return View(sessionDb);
        }

        // GET: SessionDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SessionDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,session_key,session_name,date_start,date_end,gmt_offset,session_type,meeting_key,location,country_key,country_code,country_name,circuit_key,circuit_short_name,year")] SessionDb sessionDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sessionDb);
        }

        // GET: SessionDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionDb = await _context.Sessions.FindAsync(id);
            if (sessionDb == null)
            {
                return NotFound();
            }
            return View(sessionDb);
        }

        // POST: SessionDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,session_key,session_name,date_start,date_end,gmt_offset,session_type,meeting_key,location,country_key,country_code,country_name,circuit_key,circuit_short_name,year")] SessionDb sessionDb)
        {
            if (id != sessionDb.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionDbExists(sessionDb.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sessionDb);
        }

        // GET: SessionDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionDb = await _context.Sessions
                .FirstOrDefaultAsync(m => m.id == id);
            if (sessionDb == null)
            {
                return NotFound();
            }

            return View(sessionDb);
        }

        // POST: SessionDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessionDb = await _context.Sessions.FindAsync(id);
            if (sessionDb != null)
            {
                _context.Sessions.Remove(sessionDb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionDbExists(int id)
        {
            return _context.Sessions.Any(e => e.id == id);
        }

        public ActionResult YourAction()
        {
            return View("Index");
        }
    }
}
