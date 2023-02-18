using Orders.Entities;
using System;

namespace Orders.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Prod { get; set; }

        public OrderItem() { }
        public OrderItem(int quantity, Product prod)
        {
            Quantity = quantity;
            Prod = prod;
        }

        public double SubTotal()
        {
            Price = Prod.Price;
            return Price * Quantity;
        }
    }
}
