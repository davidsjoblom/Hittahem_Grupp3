#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HittaHem.Mvc.Data;
using HittaHemEntityModels;

namespace HittaHem.Mvc.Controllers
{
    public class HomeViewingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeViewingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeViewings
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeViewings.ToListAsync());
        }

        // GET: HomeViewings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeViewing = await _context.HomeViewings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeViewing == null)
            {
                return NotFound();
            }

            return View(homeViewing);
        }

        // GET: HomeViewings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeViewings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ViewingDate")] HomeViewing homeViewing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeViewing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeViewing);
        }

        // GET: HomeViewings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeViewing = await _context.HomeViewings.FindAsync(id);
            if (homeViewing == null)
            {
                return NotFound();
            }
            return View(homeViewing);
        }

        // POST: HomeViewings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ViewingDate")] HomeViewing homeViewing)
        {
            if (id != homeViewing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeViewing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeViewingExists(homeViewing.Id))
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
            return View(homeViewing);
        }

        // GET: HomeViewings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeViewing = await _context.HomeViewings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeViewing == null)
            {
                return NotFound();
            }

            return View(homeViewing);
        }

        // POST: HomeViewings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeViewing = await _context.HomeViewings.FindAsync(id);
            _context.HomeViewings.Remove(homeViewing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeViewingExists(int id)
        {
            return _context.HomeViewings.Any(e => e.Id == id);
        }
    }
}
