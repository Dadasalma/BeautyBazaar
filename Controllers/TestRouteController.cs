using Microsoft.AspNetCore.Mvc;

namespace BeautyBazaar.Controllers
{
    public class TestRouteController : Controller
    {
        // GET: /TestRoute/Index
        public IActionResult Index()
        {
            return Content(@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Route Test</title>
                    <style>
                        body { background: #000; color: #ff0080; padding: 50px; }
                        a { color: #ff0080; display: block; margin: 10px 0; font-size: 20px; }
                        .test-box { border: 2px solid #ff0080; padding: 20px; margin: 20px 0; }
                        .success { color: #00ff00; }
                    </style>
                </head>
                <body>
                    <h1>✅ Route Test Controller is Working!</h1>
                    
                    <div class='test-box'>
                        <h3>Test Links from TestRouteController:</h3>
                        <a href='/TestRoute/Simple'>→ /TestRoute/Simple</a>
                        <a href='/TestRoute/Json'>→ /TestRoute/Json</a>
                        <a href='/TestRoute/Html'>→ /TestRoute/Html</a>
                    </div>
                    
                    <div class='test-box'>
                        <h3>Try These URLs:</h3>
                        <a href='/'>→ Home Page</a>
                        <a href='/Products'>→ Products Page</a>
                        <a href='/debug-routes'>→ Debug Routes</a>
                    </div>
                </body>
                </html>
            ", "text/html");
        }

        // GET: /TestRoute/Simple
        public IActionResult Simple()
        {
            return Content("Simple test - Route is working!", "text/plain");
        }

        // GET: /TestRoute/Json
        public IActionResult Json()
        {
            return Json(new
            {
                Status = "OK",
                Message = "JSON test successful",
                Timestamp = DateTime.UtcNow
            });
        }

        // GET: /TestRoute/Html
        public IActionResult Html()
        {
            return Content("<h1 style='color:#ff0080;'>HTML Response Test</h1><p>This is HTML content</p>", "text/html");
        }
    }
}