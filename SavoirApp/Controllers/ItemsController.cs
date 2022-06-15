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
        
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }
        

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["Brand"] = new SelectList(_context.Items, "ID", "ID");

            return View();
        }

        
        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,ItemDetails,Quantity,Gender,ImageURL,Brand,InStock")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,ItemDetails,Quantity,Gender,ImageURL,Brand,InStock")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id)
        {
           var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Order narudzba;
            if (!OrderExists())
            {
                var order = new Order(userId);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
             narudzba = _context.Orders.First(m => m.IDUser == userId);
            OrderItems oi = new OrderItems(narudzba.ID, id);
            _context.OrderItems.Add(oi);
        //    narudzba.izracunajCijenu();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [Authorize]
        // GET: Items
        public async Task<IActionResult> Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var narudzba = _context.Orders.FirstOrDefault(m => m.IDUser == userId);
            IQueryable<OrderItems> orderItems = _context.OrderItems.Where(it => it.IDOrder == narudzba.ID);
            List<Item> listaItemaZaPrikaz = new List<Item>();

            if(orderItems != null)
                foreach (OrderItems par in orderItems)
                {
                    var item = _context.Items.FirstOrDefault(it => it.ID == par.IDItem);
                    if(item != null)
                        listaItemaZaPrikaz.Add(item);
                }
            return View(listaItemaZaPrikaz);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var narudzba = _context.Orders.FirstOrDefault(m => m.IDUser == userId);

            if(narudzba != null)
            {
                var orderItems = _context.OrderItems.FirstOrDefault(it => it.IDOrder == narudzba.ID && it.IDItem == id);

                if(orderItems != null)
                {
                    _context.OrderItems.Remove(orderItems);
                    await _context.SaveChangesAsync();
                }
            }
            

            return RedirectToAction(nameof(Cart));
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


        private bool OrderExists()
        {
                 var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 return _context.Orders.Any(m => m.IDUser == userId);
        }
    }
}
