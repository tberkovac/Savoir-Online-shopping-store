using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Data;
using SavoirApp.Models;

namespace SavoirApp.Controllers
{
    public class VIPUserOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VIPUserOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VIPUserOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VIPUserOrders.Include(v => v.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VIPUserOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIPUserOrders = await _context.VIPUserOrders
                .Include(v => v.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vIPUserOrders == null)
            {
                return NotFound();
            }

            return View(vIPUserOrders);
        }

        // GET: VIPUserOrders/Create
        public IActionResult Create()
        {
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID");
            return View();
        }

        // POST: VIPUserOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDUser,IDOrder")] VIPUserOrders vIPUserOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vIPUserOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", vIPUserOrders.IDOrder);
            return View(vIPUserOrders);
        }

        // GET: VIPUserOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIPUserOrders = await _context.VIPUserOrders.FindAsync(id);
            if (vIPUserOrders == null)
            {
                return NotFound();
            }
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", vIPUserOrders.IDOrder);
            return View(vIPUserOrders);
        }

        // POST: VIPUserOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDUser,IDOrder")] VIPUserOrders vIPUserOrders)
        {
            if (id != vIPUserOrders.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vIPUserOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VIPUserOrdersExists(vIPUserOrders.ID))
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
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", vIPUserOrders.IDOrder);
            return View(vIPUserOrders);
        }

        // GET: VIPUserOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIPUserOrders = await _context.VIPUserOrders
                .Include(v => v.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vIPUserOrders == null)
            {
                return NotFound();
            }

            return View(vIPUserOrders);
        }

        // POST: VIPUserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vIPUserOrders = await _context.VIPUserOrders.FindAsync(id);
            _context.VIPUserOrders.Remove(vIPUserOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VIPUserOrdersExists(int id)
        {
            return _context.VIPUserOrders.Any(e => e.ID == id);
        }
    }
}
