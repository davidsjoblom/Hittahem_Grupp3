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
    public class HomeImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HomeImages.Include(h => h.Home);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HomeImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImages
                .Include(h => h.Home)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // GET: HomeImages/Create
        public IActionResult Create()
        {
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "UserId");
            return View();
        }

        // POST: HomeImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,HomeId,UploadingDate")] HomeImage homeImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "UserId", homeImage.HomeId);
            return View(homeImage);
        }

        // GET: HomeImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImages.FindAsync(id);
            if (homeImage == null)
            {
                return NotFound();
            }
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "UserId", homeImage.HomeId);
            return View(homeImage);
        }

        // POST: HomeImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,HomeId,UploadingDate")] HomeImage homeImage)
        {
            if (id != homeImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeImageExists(homeImage.Id))
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
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "UserId", homeImage.HomeId);
            return View(homeImage);
        }

        // GET: HomeImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImages
                .Include(h => h.Home)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // POST: HomeImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeImage = await _context.HomeImages.FindAsync(id);
            _context.HomeImages.Remove(homeImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeImageExists(int id)
        {
            return _context.HomeImages.Any(e => e.Id == id);
        }
    }
}
