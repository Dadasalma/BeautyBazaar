namespace BeautyBazaar.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Total => Price * Quantity;
    }

    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice => Items.Sum(i => i.Total);
        public int TotalItems => Items.Sum(i => i.Quantity);
    }
}
