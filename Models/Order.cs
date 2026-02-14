using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyBazaar.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; }  // Linked to Identity User
        
        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
        
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        
        [StringLength(100)]
        public string Address2 { get; set; }
        
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        
        [StringLength(20)]
        public string PostalCode { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        
        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
        
        // Helper property to calculate line total
        [NotMapped]
        public decimal LineTotal => Quantity * UnitPrice;
    }
}
