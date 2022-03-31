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
    public class HousingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HousingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HousingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HousingTypes.ToListAsync());
        }

        // GET: HousingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingType = await _context.HousingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (housingType == null)
            {
                return NotFound();
            }

            return View(housingType);
        }

        // GET: HousingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HousingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] HousingType housingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(housingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(housingType);
        }

        // GET: HousingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingType = await _context.HousingTypes.FindAsync(id);
            if (housingType == null)
            {
                return NotFound();
            }
            return View(housingType);
        }

        // POST: HousingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] HousingType housingType)
        {
            if (id != housingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(housingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HousingTypeExists(housingType.Id))
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
            return View(housingType);
        }

        // GET: HousingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housingType = await _context.HousingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (housingType == null)
            {
                return NotFound();
            }

            return View(housingType);
        }

        // POST: HousingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var housingType = await _context.HousingTypes.FindAsync(id);
            _context.HousingTypes.Remove(housingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HousingTypeExists(int id)
        {
            return _context.HousingTypes.Any(e => e.Id == id);
        }
    }
}
