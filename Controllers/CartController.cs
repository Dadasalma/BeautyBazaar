using BeautyBazaar.Data;
using BeautyBazaar.Extensions;
using BeautyBazaar.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBazaar.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.Get<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ImageUrl = product.ImageUrl
                });
            }

            HttpContext.Session.Set(CartSessionKey, cart);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.Get<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                cart.Items.Remove(item);
            }

            HttpContext.Session.Set(CartSessionKey, cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            if (quantity <= 0) return RemoveFromCart(productId);

            var cart = HttpContext.Session.Get<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity;
            }

            HttpContext.Session.Set(CartSessionKey, cart);
            return RedirectToAction(nameof(Index));
        }
    }
}
