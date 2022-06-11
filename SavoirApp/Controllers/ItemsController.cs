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
        public IActionResult Create()
        {
            ViewData["Brand"] = new SelectList(_context.Items, "ID", "ID");

            return View();
        }

        /*
        //Post : cart
        [HttpPost]
        public async Task<IActionResult> Cart(int id)
        {
            var userOrder = User.FindFirstValue(ClaimTypes.)
            if()
            _context.Add()
        }
        */



        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Items
        public async Task<IActionResult> Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var narudzba = _context.Orders.First(m => m.IDUser == userId);
            var orderItems = _context.OrderItems.Where(it => it.IDOrder == narudzba.ID);

            List<Item> listaItemaZaPrikaz = new List<Item>();

            foreach (var par in orderItems)
            {
                var item = _context.Items.First(it => it.ID == par.IDItem);
                listaItemaZaPrikaz.Add(item);
            }
            return View(listaItemaZaPrikaz);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var narudzba = _context.Orders.First(m => m.IDUser == userId);
            var orderItems = _context.OrderItems.First(it => it.IDOrder == narudzba.ID && it.IDItem == id);

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }



        private bool OrderExists()
        {
                 var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 return _context.Orders.Any(m => m.IDUser == userId);
        }
    }
}
