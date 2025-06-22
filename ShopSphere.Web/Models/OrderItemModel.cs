﻿namespace ShopSphere.Web.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
       
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public virtual OrderModel Order { get; set; } = null!;
        public virtual ProductModel Product { get; set; } = null!;
    }
}
