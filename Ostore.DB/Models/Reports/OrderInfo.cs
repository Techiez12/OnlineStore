using System;

namespace Ostore.DB.Models
{
    public class OrderInfo : Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
