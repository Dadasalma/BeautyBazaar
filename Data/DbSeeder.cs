using BeautyBazaar.Models;
using Microsoft.AspNetCore.Identity;

namespace BeautyBazaar.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Seed Roles
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed Admin User
            var adminEmail = "admin@beautybazaar.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "Bazaar",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var createPowerUser = await userManager.CreateAsync(adminUser, "Admin123!");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            else
            {
                // Ensure role for existing admin
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        public static async Task SeedProductsAsync(ApplicationDbContext context)
        {
            // Clear existing products for a clean "real" catalog
            context.Products.RemoveRange(context.Products);
            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                // --- SKINCARE ---
                new Product {
                    Name = "Cicaplast Baume B5+",
                    Brand = "La Roche-Posay",
                    Description = "Multi-purpose repairing balm for sensitive skin. Soothes and protects.",
                    Price = 179.00m,
                    StockQuantity = 50,
                    Category = "Skincare",
                    ImageUrl = "/images/products/skincare1.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Crème Hydratante Visage",
                    Brand = "CeraVe",
                    Description = "Daily moisturizing face cream for normal to dry skin.",
                    Price = 102.00m,
                    StockQuantity = 100,
                    Category = "Skincare",
                    ImageUrl = "/images/products/skincare2.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Effaclar Mat+",
                    Brand = "La Roche-Posay",
                    Description = "Anti-shine, anti-enlarged pores mattifying moisturizer.",
                    Price = 164.00m,
                    StockQuantity = 40,
                    Category = "Skincare",
                    ImageUrl = "/images/products/skincare3.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Gel-Crème Hydratant",
                    Brand = "CeraVe",
                    Description = "Oil Control moisturizing gel-cream.",
                    Price = 104.00m,
                    StockQuantity = 35,
                    Category = "Skincare",
                    ImageUrl = "/images/products/skincare4.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Ialuset Crème",
                    Brand = "Ialuset",
                    Description = "Pure hyaluronic acid cream for intense hydration.",
                    Price = 165.00m,
                    StockQuantity = 20,
                    Category = "Skincare",
                    ImageUrl = "/images/products/skincare1.png",
                    CreatedAt = DateTime.UtcNow
                },

                // --- MAKEUP ---
                new Product {
                    Name = "Hyper Lash Mascara",
                    Brand = "Catrice",
                    Description = "Extreme volume and length mascara for dramatic lashes.",
                    Price = 65.00m,
                    StockQuantity = 120,
                    Category = "Makeup",
                    ImageUrl = "/images/products/makeup1.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Poudre Sun Bright",
                    Brand = "Golden Rose",
                    Description = "Illuminating bronzing powder for a sun-kissed cyber glow.",
                    Price = 85.00m,
                    StockQuantity = 45,
                    Category = "Makeup",
                    ImageUrl = "/images/products/makeup2.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Fixing Spray Matte",
                    Brand = "Golden Rose",
                    Description = "Long-lasting mattifying setting spray to lock in your look.",
                    Price = 84.00m,
                    StockQuantity = 55,
                    Category = "Makeup",
                    ImageUrl = "/images/products/makeup3.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Lip Tint Essence",
                    Brand = "Essence",
                    Description = "Hydra Kiss lip tint for a natural flush.",
                    Price = 33.00m,
                    StockQuantity = 90,
                    Category = "Makeup",
                    ImageUrl = "/images/products/makeup4.png",
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Waterproof Kajal",
                    Brand = "Catrice",
                    Description = "Kohl Kajal waterproof pencil for intense eyes.",
                    Price = 25.00m,
                    StockQuantity = 150,
                    Category = "Makeup",
                    ImageUrl = "/images/products/makeup5.png",
                    CreatedAt = DateTime.UtcNow
                },

                // --- PARFUMES ---
                new Product {
                    Name = "Cyber Scent No. 1",
                    Brand = "BeautyBazaar",
                    Description = "A futuristic floral scent with notes of neon and amber.",
                    Price = 450.00m,
                    StockQuantity = 15,
                    Category = "Parfumes",
                    ImageUrl = "/images/products/makeup1.png", // Temporarily using makeup image
                    CreatedAt = DateTime.UtcNow
                },
                new Product {
                    Name = "Midnight Glitch",
                    Brand = "BeautyBazaar",
                    Description = "Dark, mysterious oud with a sharp metallic edge.",
                    Price = 520.00m,
                    StockQuantity = 10,
                    Category = "Parfumes",
                    ImageUrl = "/images/products/makeup2.png",
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
