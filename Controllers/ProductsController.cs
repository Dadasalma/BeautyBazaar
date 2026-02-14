using BeautyBazaar.Data;
using BeautyBazaar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _context.Products
                    .Where(p => p.IsActive)
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products");
                return View(new List<Product>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading product details for ID: {ProductId}", id);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return RedirectToAction(nameof(Index));
                }

                var products = await _context.Products
                    .Where(p => p.IsActive &&
                               (p.Name.Contains(searchTerm) ||
                                p.Description.Contains(searchTerm) ||
                                p.Brand.Contains(searchTerm) ||
                                p.Category.Contains(searchTerm)))
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                ViewBag.SearchTerm = searchTerm;
                return View("Index", products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching products with term: {SearchTerm}", searchTerm);
                return RedirectToAction(nameof(Index));
            }
        }

        // New actions for categories
        public async Task<IActionResult> Category(string category)
        {
            try
            {
                var products = await _context.Products
                    .Where(p => p.IsActive && p.Category == category)
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                ViewBag.Category = category;
                return View("Index", products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products for category: {Category}", category);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> New()
        {
            try
            {
                var products = await _context.Products
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(20)
                    .ToListAsync();

                ViewBag.Category = "New Arrivals";
                return View("Index", products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading new products");
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> BestSellers()
        {
            try
            {
                var products = await _context.Products
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.StockQuantity)
                    .Take(20)
                    .ToListAsync();

                ViewBag.Category = "Best Sellers";
                return View("Index", products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading best sellers");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}