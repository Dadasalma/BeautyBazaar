using BeautyBazaar.Data;
using BeautyBazaar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity WITH Default UI
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // SESSION BEFORE AUTH
app.UseAuthentication();
app.UseAuthorization();

// Map controller route FIRST
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Then map Razor Pages
app.MapRazorPages();

// TEST ENDPOINTS - Add these BEFORE app.Run()
app.MapGet("/test-simple", () => "Simple test endpoint is working!");
app.MapGet("/test-html", () => Results.Content("<h1 style='color:red;'>HTML Test</h1><p>This endpoint works!</p>", "text/html"));
app.MapGet("/test-json", () => Results.Json(new { status = "OK", message = "JSON test works" }));

// Direct Identity test endpoints
app.MapGet("/register-test", () => Results.Content(@"
    <!DOCTYPE html>
    <html>
    <head><title>Register Test</title></head>
    <body style='background:black;color:#ff0080;padding:50px;'>
        <h1>Register Page Test</h1>
        <p>This is a static test page.</p>
        <p><a href='/Identity/Account/Register' style='color:#00ff00;'>Try Identity Register</a></p>
        <p><a href='/' style='color:#ff0080;'>Back to Home</a></p>
    </body>
    </html>
", "text/html"));

app.MapGet("/login-test", () => Results.Content(@"
    <!DOCTYPE html>
    <html>
    <head><title>Login Test</title></head>
    <body style='background:black;color:#ff0080;padding:50px;'>
        <h1>Login Page Test</h1>
        <p>This is a static test page.</p>
        <p><a href='/Identity/Account/Login' style='color:#00ff00;'>Try Identity Login</a></p>
        <p><a href='/' style='color:#ff0080;'>Back to Home</a></p>
    </body>
    </html>
", "text/html"));

app.MapGet("/check-routes", async (HttpContext context) =>
{
    var routes = new[]
    {
        "/",
        "/Home/Index",
        "/Products",
        "/TestRoute",
        "/TestRoute/Simple",
        "/test-simple",
        "/test-html",
        "/test-json",
        "/register-test",
        "/login-test",
        "/Identity/Account/Register",
        "/Identity/Account/Login"
    };

    var sb = new System.Text.StringBuilder();
    sb.AppendLine("<!DOCTYPE html><html><head><title>Route Checker</title>");
    sb.AppendLine("<style>body {background:#000;color:#ff0080;padding:20px;}");
    sb.AppendLine(".route {margin:5px 0;} .working {color:#00ff00;} .broken {color:#ff0000;}");
    sb.AppendLine("</style></head><body><h1>Route Checker</h1>");

    foreach (var route in routes)
    {
        try
        {
            var request = context.Request;
            var fullUrl = $"{request.Scheme}://{request.Host}{route}";
            sb.AppendLine($"<div class='route'>");
            sb.AppendLine($"<a href='{route}'>{route}</a>");
            sb.AppendLine($"<span class='working'> → Should work</span>");
            sb.AppendLine($"</div>");
        }
        catch
        {
            sb.AppendLine($"<div class='route'>{route} <span class='broken'>→ ERROR</span></div>");
        }
    }

    sb.AppendLine("</body></html>");
    return Results.Content(sb.ToString(), "text/html");
});

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed Roles and Admin User
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);

    // Seed Real Products from Images
    await DbSeeder.SeedProductsAsync(context);
}

app.Run();