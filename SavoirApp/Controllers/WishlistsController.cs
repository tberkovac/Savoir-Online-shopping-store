using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Data;
using SavoirApp.Models;

namespace SavoirApp.Controllers
{
    [Authorize(Roles ="Admin, VIPUser")]
    public class WishlistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wishlists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wishlists.Include(w => w.Item);
                //Wishlists.Include(w => w.Item);
     
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlists
                .Include(w => w.Item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // GET: Wishlists/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["IDItem"] = new SelectList(_context.Items, "ID", "ID");

            return View();
        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDItem")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDItem"] = new SelectList(_context.Items, "ID", "ID", wishlist.IDItem);
            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            ViewData["IDItem"] = new SelectList(_context.Items, "ID", "ID", wishlist.IDItem);
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDItem")] Wishlist wishlist)
        {
            if (id != wishlist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistExists(wishlist.ID))
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
            ViewData["IDItem"] = new SelectList(_context.Items, "ID", "ID", wishlist.IDItem);
            return View(wishlist);
        }

        [Authorize(Roles = "Admin")]
        // GET: Wishlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlists
                .Include(w => w.Item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistExists(int id)
        {
            return _context.Wishlists.Any(e => e.ID == id);
        }

        [Authorize(Roles = "VIPUser")]
        // GET: Items
        public async Task<IActionResult> Wishlist()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wish = _context.Wishlists.ToList().FindAll(m => m.IDUser == userId);

            List<Item> listaItemaZaPrikaz = new List<Item>();

            if (wish != null)
                foreach (Wishlist par in wish)
                {
                    var item = _context.Items.FirstOrDefault(it => it.ID == par.IDItem);
                    if (item != null)
                        listaItemaZaPrikaz.Add(item);
                }
            return View(listaItemaZaPrikaz);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWishlist(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var oi = new Wishlist(id, userId);
            _context.Wishlists.Add(oi);
         
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
