using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Data;
using SavoirApp.Models;

namespace SavoirApp.Controllers
{
    [Authorize(Roles = "Admin, RegisteredUser, VIPUser")]
    public class RegisteredUserOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisteredUserOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegisteredUserOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegisteredUserOrders.Include(r => r.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegisteredUserOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredUserOrders = await _context.RegisteredUserOrders
                .Include(r => r.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registeredUserOrders == null)
            {
                return NotFound();
            }

            return View(registeredUserOrders);
        }

        // GET: RegisteredUserOrders/Create
        public IActionResult Create()
        {
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID");
            return View();
        }


        public async Task<IActionResult> OrderList()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var t = _context.RegisteredUserOrders.FromSqlRaw("SELECT * FROM RegisteredUserOrders o WHERE o.IDUser = {0}", UserId).ToList();
            return View(t);
        }

        // POST: RegisteredUserOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDUser,IDOrder")] RegisteredUserOrders registeredUserOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registeredUserOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", registeredUserOrders.IDOrder);
            return View(registeredUserOrders);
        }

        // GET: RegisteredUserOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredUserOrders = await _context.RegisteredUserOrders.FindAsync(id);
            if (registeredUserOrders == null)
            {
                return NotFound();
            }
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", registeredUserOrders.IDOrder);
            return View(registeredUserOrders);
        }

        // POST: RegisteredUserOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDUser,IDOrder")] RegisteredUserOrders registeredUserOrders)
        {
            if (id != registeredUserOrders.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registeredUserOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisteredUserOrdersExists(registeredUserOrders.ID))
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
            ViewData["IDOrder"] = new SelectList(_context.Orders, "ID", "ID", registeredUserOrders.IDOrder);
            return View(registeredUserOrders);
        }

        // GET: RegisteredUserOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredUserOrders = await _context.RegisteredUserOrders
                .Include(r => r.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registeredUserOrders == null)
            {
                return NotFound();
            }

            return View(registeredUserOrders);
        }

        // POST: RegisteredUserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registeredUserOrders = await _context.RegisteredUserOrders.FindAsync(id);
            _context.RegisteredUserOrders.Remove(registeredUserOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisteredUserOrdersExists(int id)
        {
            return _context.RegisteredUserOrders.Any(e => e.ID == id);
        }
    }
}
