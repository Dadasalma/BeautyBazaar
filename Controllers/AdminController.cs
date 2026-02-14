using BeautyBazaar.Data;
using BeautyBazaar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Controllers
{
    [Authorize(Roles = "Admin")] // SEULEMENT POUR LES ADMINS
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Admin/ - Page d'accueil admin
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Admin/Products - Liste tous les produits
        public async Task<IActionResult> Products()
        {
            var products = await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();
            return View(products);
        }

        // GET: /Admin/Products/Create - Formulaire création
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.UtcNow;
                product.UpdatedAt = DateTime.UtcNow;

                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        // GET: /Admin/Products/Edit/5 - Formulaire modification
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.UpdatedAt = DateTime.UtcNow;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        // GET: /Admin/Products/Delete/5 - Confirmation suppression
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }

        // GET: /Admin/Users - Liste tous les utilisateurs (pour l'admin)
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users
                .OrderBy(u => u.Email)
                .ToListAsync();
            return View(users);
        }

        // GET: /Admin/Sales - Liste toutes les commandes (Ventes)
        public async Task<IActionResult> Sales()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            return View(orders);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}