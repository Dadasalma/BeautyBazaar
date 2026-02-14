using BeautyBazaar.Data;
using BeautyBazaar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddProducts()
        {
            // Check if products already exist
            if (await _context.Products.AnyAsync())
            {
                return Content("Products already exist in database!");
            }

            var products = new[]
            {
                new Product {
                    Name = "CHOCO BOMB Shiny Lip Gloss",
                    Description = "High-shine lip gloss with delicious chocolate scent",
                    Price = 15.00m,
                    StockQuantity = 50,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "/images/products/lipgloss.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "CHOCO BOMB Extreme Lengthening Mascara",
                    Description = "Tubing mascara for extreme length and volume",
                    Price = 43.00m,
                    StockQuantity = 30,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "/images/products/mascara.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Cyber Pink Highlighter",
                    Description = "Neon pink highlighter with cyber shimmer",
                    Price = 32.00m,
                    StockQuantity = 25,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "/images/products/highlighter.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Neon Glow Serum",
                    Description = "Hydrating serum with neon glow effect",
                    Price = 45.00m,
                    StockQuantity = 35,
                    Category = "Skincare",
                    Brand = "BeautyBazaar",
                    ImageUrl = "/images/products/serum.jpg",
                    CreatedAt = DateTime.UtcNow
                }
            };

            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();

            return Content($"{products.Length} products added successfully! Go to /Home to see them.");
        }
    }
}