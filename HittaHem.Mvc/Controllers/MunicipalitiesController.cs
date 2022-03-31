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
    public class MunicipalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MunicipalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Municipalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipalities.ToListAsync());
        }

        // GET: Municipalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }

            return View(municipality);
        }

        // GET: Municipalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Municipality municipality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipality);
        }

        // GET: Municipalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipalities.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }
            return View(municipality);
        }

        // POST: Municipalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Municipality municipality)
        {
            if (id != municipality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipalityExists(municipality.Id))
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
            return View(municipality);
        }

        // GET: Municipalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }

            return View(municipality);
        }

        // POST: Municipalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);
            _context.Municipalities.Remove(municipality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipalityExists(int id)
        {
            return _context.Municipalities.Any(e => e.Id == id);
        }
    }
}
