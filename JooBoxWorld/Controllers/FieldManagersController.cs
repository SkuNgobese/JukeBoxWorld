using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JooBoxWorld.Data;
using JooBoxWorld.Models;
using Microsoft.AspNetCore.Identity;

namespace JooBoxWorld.Controllers
{
    public class FieldManagersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FieldManagersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FieldManagers
        public async Task<IActionResult> Index()
        {
            var fieldManagers = _context.FieldManagers.Include(f => f.ApplicationUser).Include(a=>a.Agents);
            TempData["voucher"] = _context.Vouchers.Include(a=>a.ApplicationUser).ToList();
            return View(await fieldManagers.ToListAsync());
        }

        // GET: FieldManagers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldManager = await _context.FieldManagers
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldManager == null)
            {
                return NotFound();
            }

            return View(fieldManager);
        }

        // GET: FieldManagers/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: FieldManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Location,CreatedDate,IsActive")] FieldManager fieldManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", fieldManager.Id);
            return View(fieldManager);
        }

        // GET: FieldManagers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldManager = await _context.FieldManagers.FindAsync(id);
            if (fieldManager == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", fieldManager.Id);
            return View(fieldManager);
        }

        // POST: FieldManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Amount,Location,CreatedDate,IsActive")] FieldManager fieldManager)
        {
            if (id != fieldManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldManagerExists(fieldManager.Id))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", fieldManager.Id);
            return View(fieldManager);
        }

        // GET: FieldManagers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldManager = await _context.FieldManagers
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldManager == null)
            {
                return NotFound();
            }

            return View(fieldManager);
        }

        // POST: FieldManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldManager = await _context.FieldManagers.FindAsync(id);
            _context.FieldManagers.Remove(fieldManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldManagerExists(string id)
        {
            return _context.FieldManagers.Any(e => e.Id == id);
        }
    }
}
