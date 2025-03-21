using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace WebApplication1.Controllers
{
    public class CosmeticInformationsController : Controller
    {
        private readonly Sp25CosmeticsDBContext _context;

        public CosmeticInformationsController(Sp25CosmeticsDBContext context)
        {
            _context = context;
        }

        // GET: CosmeticInformations
        public async Task<IActionResult> Index()
        {
            var sp25CosmeticsDBContext = _context.CosmeticInformations.Include(c => c.Category);
            return View(await sp25CosmeticsDBContext.ToListAsync());
        }

        // GET: CosmeticInformations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmeticInformation = await _context.CosmeticInformations
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CosmeticId == id);
            if (cosmeticInformation == null)
            {
                return NotFound();
            }

            return View(cosmeticInformation);
        }

        // GET: CosmeticInformations/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CosmeticCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: CosmeticInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CosmeticId,CosmeticName,SkinType,ExpirationDate,CosmeticSize,DollarPrice,CategoryId")] CosmeticInformation cosmeticInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cosmeticInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CosmeticCategories, "CategoryId", "CategoryId", cosmeticInformation.CategoryId);
            return View(cosmeticInformation);
        }

        // GET: CosmeticInformations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmeticInformation = await _context.CosmeticInformations.FindAsync(id);
            if (cosmeticInformation == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CosmeticCategories, "CategoryId", "CategoryId", cosmeticInformation.CategoryId);
            return View(cosmeticInformation);
        }

        // POST: CosmeticInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CosmeticId,CosmeticName,SkinType,ExpirationDate,CosmeticSize,DollarPrice,CategoryId")] CosmeticInformation cosmeticInformation)
        {
            if (id != cosmeticInformation.CosmeticId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cosmeticInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosmeticInformationExists(cosmeticInformation.CosmeticId))
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
            ViewData["CategoryId"] = new SelectList(_context.CosmeticCategories, "CategoryId", "CategoryId", cosmeticInformation.CategoryId);
            return View(cosmeticInformation);
        }

        // GET: CosmeticInformations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmeticInformation = await _context.CosmeticInformations
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CosmeticId == id);
            if (cosmeticInformation == null)
            {
                return NotFound();
            }

            return View(cosmeticInformation);
        }

        // POST: CosmeticInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cosmeticInformation = await _context.CosmeticInformations.FindAsync(id);
            if (cosmeticInformation != null)
            {
                _context.CosmeticInformations.Remove(cosmeticInformation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CosmeticInformationExists(string id)
        {
            return _context.CosmeticInformations.Any(e => e.CosmeticId == id);
        }
    }
}
