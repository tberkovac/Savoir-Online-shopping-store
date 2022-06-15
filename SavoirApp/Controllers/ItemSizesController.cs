using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Data;
using SavoirApp.Models;

namespace SavoirApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemSizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemSizes.ToListAsync());
        }

        // GET: ItemSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSizes = await _context.ItemSizes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemSizes == null)
            {
                return NotFound();
            }

            return View(itemSizes);
        }

        // GET: ItemSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDItem,Size")] ItemSizes itemSizes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemSizes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemSizes);
        }

        // GET: ItemSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSizes = await _context.ItemSizes.FindAsync(id);
            if (itemSizes == null)
            {
                return NotFound();
            }
            return View(itemSizes);
        }

        // POST: ItemSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDItem,Size")] ItemSizes itemSizes)
        {
            if (id != itemSizes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemSizes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemSizesExists(itemSizes.ID))
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
            return View(itemSizes);
        }

        // GET: ItemSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemSizes = await _context.ItemSizes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemSizes == null)
            {
                return NotFound();
            }

            return View(itemSizes);
        }

        // POST: ItemSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemSizes = await _context.ItemSizes.FindAsync(id);
            _context.ItemSizes.Remove(itemSizes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemSizesExists(int id)
        {
            return _context.ItemSizes.Any(e => e.ID == id);
        }
    }
}
