using BeautyBazaar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBazaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Simple test endpoints
        [Route("test-simple")]
        public IActionResult TestSimple()
        {
            return Content("✅ Simple test works!", "text/plain");
        }

        [Route("test-html")]
        public IActionResult TestHtml()
        {
            return Content(@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Test</title>
                    <style>
                        body { background: #000; color: #ff0080; padding: 50px; }
                        a { color: #00ff00; }
                    </style>
                </head>
                <body>
                    <h1>✅ HTML Test Works!</h1>
                    <p><a href='/'>Go to Home</a></p>
                </body>
                </html>
            ", "text/html");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featuredProducts = await _context.Products
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(8)
                    .ToListAsync();

                return View(featuredProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading featured products");
                return View(new List<BeautyBazaar.Models.Product>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        // New actions for cart and account
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        // Debug page
        [Route("debug")]
        public IActionResult DebugPage()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Debug</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { background: #000; color: #ff0080; padding: 20px; }");
            sb.AppendLine(".route { margin: 10px 0; padding: 10px; background: #1a1a1a; }");
            sb.AppendLine("a { color: #00ff00; text-decoration: none; }");
            sb.AppendLine("a:hover { text-decoration: underline; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h1>🔧 Debug Page</h1>");

            sb.AppendLine("<div class='route'>");
            sb.AppendLine("<h3>Test Links:</h3>");
            sb.AppendLine("<a href='/test-simple'>/test-simple</a><br>");
            sb.AppendLine("<a href='/test-html'>/test-html</a><br>");
            sb.AppendLine("<a href='/'>/ (Home)</a><br>");
            sb.AppendLine("<a href='/Products'>/Products</a>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class='route'>");
            sb.AppendLine("<h3>Identity Links:</h3>");
            sb.AppendLine("<a href='/Identity/Account/Register'>/Identity/Account/Register</a><br>");
            sb.AppendLine("<a href='/Identity/Account/Login'>/Identity/Account/Login</a><br>");
            sb.AppendLine("<a href='/Identity/Account/Logout'>/Identity/Account/Logout</a>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class='route'>");
            sb.AppendLine("<h3>User Info:</h3>");
            sb.AppendLine($"<p>Is Authenticated: {(User.Identity?.IsAuthenticated == true ? "✅ YES" : "❌ NO")}</p>");
            sb.AppendLine($"<p>Username: {User.Identity?.Name ?? "Not logged in"}</p>");
            sb.AppendLine($"<p>Is Admin: {(User.IsInRole("Admin") ? "✅ YES" : "❌ NO")}</p>");
            sb.AppendLine("</div>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return Content(sb.ToString(), "text/html");
        }
    }
}