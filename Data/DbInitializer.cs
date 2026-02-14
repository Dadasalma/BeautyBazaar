using BeautyBazaar.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            // Apply pending migrations
            await context.Database.MigrateAsync();

            // Clear existing data to ensure fresh start
            await context.Products.ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            var products = new[]
            {
                // ORIGINAL BEAUTYBAZAAR PRODUCTS FROM YOUR IMAGES
                new Product {
                    Name = "Cyber Pink Highlighter",
                    Description = "Neon pink highlighter with cyber shimmer for an ultra-glowing finish",
                    Price = 32.00m,
                    StockQuantity = 45,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "CHOCO BOMB Shiny Lip Gloss",
                    Description = "High-shine lip gloss with delicious chocolate scent",
                    Price = 15.00m,
                    StockQuantity = 50,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "CHOCO BOMB Extreme Lengthening Mascara",
                    Description = "Tubing mascara for extreme length and volume",
                    Price = 43.00m,
                    StockQuantity = 30,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "VEGAN CLEAN Shiny Lip Gloss",
                    Description = "Vegan and clean formula shiny lip gloss",
                    Price = 19.00m,
                    StockQuantity = 25,
                    Category = "Makeup",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Neon Glow Serum",
                    Description = "Hydrating serum with neon glow effect",
                    Price = 45.00m,
                    StockQuantity = 35,
                    Category = "Skincare",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Pink Cyber Body Butter",
                    Description = "Nourishing body butter with cyber pink scent",
                    Price = 28.00m,
                    StockQuantity = 60,
                    Category = "Body Care",
                    Brand = "BeautyBazaar",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },

                // HUDA BEAUTY PRODUCTS
                new Product {
                    Name = "Ethereal Blush Trio & Brush Kit",
                    Description = "Three beautiful blush shades with premium brush",
                    Price = 147.00m,
                    StockQuantity = 25,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Baby Pink Blush Filter Kit",
                    Description = "Soft baby pink blush for a natural flush",
                    Price = 89.00m,
                    StockQuantity = 30,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Toasty Peach Blush Filter Kit",
                    Description = "Warm peach blush for a sun-kissed glow",
                    Price = 89.00m,
                    StockQuantity = 30,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Rose Berry Blush Filter Kit",
                    Description = "Rich rose berry blush for a bold look",
                    Price = 89.00m,
                    StockQuantity = 30,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Blush & Brush Kit",
                    Description = "Complete blush application kit with brush",
                    Price = 77.00m,
                    StockQuantity = 35,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-1cf44a2c4ffe?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Mini Blur & Set Duo",
                    Description = "Mini pore blurring and setting powder duo",
                    Price = 39.00m,
                    StockQuantity = 40,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-1cf44a2c4ffe?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Lip Contour Stain Kit",
                    Description = "Complete lip contouring and staining kit",
                    Price = 128.00m,
                    StockQuantity = 20,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Lip Stain & Oil Kit",
                    Description = "Long-lasting lip stain with nourishing oil",
                    Price = 97.00m,
                    StockQuantity = 25,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Jelly Stained Lip Kit",
                    Description = "Jelly-textured lip stain for glossy color",
                    Price = 57.00m,
                    StockQuantity = 35,
                    Category = "Makeup",
                    Brand = "HUDA BEAUTY",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },

                // GOLDEN ROSE PRODUCTS
                new Product {
                    Name = "Gel WAX POUR LES SOURCILS Golden Rose",
                    Description = "Eyebrow wax gel for perfect brow styling",
                    Price = 65.00m,
                    StockQuantity = 50,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-1cf44a2c4ffe?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "ROUGE A LEVRES EN POUDRE PURE MATTE GR",
                    Description = "Pure matte powder lipstick for velvety finish",
                    Price = 65.00m,
                    StockQuantity = 45,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "TINTED Kiss Hydrating Lip Tint Essence 106 ET 107",
                    Description = "Hydrating lip tint in shades 106 and 107",
                    Price = 33.00m,
                    StockQuantity = 60,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "MAX HOLD BROW GLUE COLLE SOURCILS GOLDEN ROSE",
                    Description = "Maximum hold brow glue for all-day perfection",
                    Price = 59.00m,
                    StockQuantity = 55,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-1cf44a2c4ffe?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Correcteur Skin Lovin' SENSITIVE Essence",
                    Description = "Sensitive skin concealer with caring essence",
                    Price = 33.00m,
                    StockQuantity = 65,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1522335789203-aabd1fc54bc9?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "FARD A JOUE LIQUIDE BABY GOT BLUSH ESSENCE",
                    Description = "Liquid blush with hydrating essence",
                    Price = 39.00m,
                    StockQuantity = 50,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "CRAYON A LEVRES 8H MATTE COMFORT ESSENCE",
                    Description = "8-hour matte lip pencil with comfort essence",
                    Price = 19.00m,
                    StockQuantity = 80,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "FARD A JOUES STICK BABY GOT BLUSH ESSENCE",
                    Description = "Cream blush stick with hydrating essence",
                    Price = 39.00m,
                    StockQuantity = 45,
                    Category = "Makeup",
                    Brand = "Golden Rose",
                    ImageUrl = "https://images.unsplash.com/photo-1571781926291-c477ebfd024b?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },

                // CATRICE PRODUCT
                new Product {
                    Name = "Catrice Plumping Lip Liner 069",
                    Description = "Plumping lip liner in shade 069",
                    Price = 27.00m,
                    StockQuantity = 70,
                    Category = "Makeup",
                    Brand = "Catrice",
                    ImageUrl = "https://images.unsplash.com/photo-1586495777744-4413f21062fa?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },

                // SKINCARE PRODUCTS
                new Product {
                    Name = "Routine éclat et hydratation",
                    Description = "Complete radiance and hydration skincare routine",
                    Price = 47.20m,
                    StockQuantity = 30,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Radiant Vita Niacinamide Real Deep Mask",
                    Description = "Deep cleansing mask with niacinamide for radiant skin",
                    Price = 5.25m,
                    StockQuantity = 100,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Bio Collagen-Real Deep Mask",
                    Description = "Collagen-infused deep hydrating mask",
                    Price = 5.25m,
                    StockQuantity = 95,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Cera-Nol Gel Toner Pads",
                    Description = "Gentle toner pads with ceramides for balanced skin",
                    Price = 19.50m,
                    StockQuantity = 60,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "The Mist Have",
                    Description = "Refreshing facial mist for instant hydration",
                    Price = 17.60m,
                    StockQuantity = 75,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Centella Cleansing Oil",
                    Description = "Gentle cleansing oil with centella asiatica",
                    Price = 23.25m,
                    StockQuantity = 55,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Sérum Yeux Éclat au Thé Vert et à La Caféine",
                    Description = "Eye serum with green tea and caffeine for bright eyes",
                    Price = 23.92m,
                    StockQuantity = 45,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Routine hydratante jour et nuit",
                    Description = "Day and night hydrating skincare routine",
                    Price = 65.52m,
                    StockQuantity = 35,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product {
                    Name = "Hydro Cera-Nol Real Deep Mask",
                    Description = "Hydro-gel mask with ceramides for deep hydration",
                    Price = 5.25m,
                    StockQuantity = 90,
                    Category = "Skincare",
                    Brand = "WISHFUL",
                    ImageUrl = "https://images.unsplash.com/photo-1556228578-2f8e02aa45e5?w=400&h=400&fit=crop",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}