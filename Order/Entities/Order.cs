using System;
using System.Globalization;
using System.Text;
using Orders.Entities.Enum;

namespace Orders.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }


        public Order() { }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double ItemTotal = 0;
            foreach (OrderItem i in Items)
            {
                ItemTotal += i.SubTotal();
            }
            return ItemTotal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Sumary");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:MM:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());

            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.AppendLine($" ({Client.BirthDate.ToString("dd/MM/yyyy")}) - {Client.Email}");

            sb.AppendLine("Order Items: ");
            foreach (OrderItem i in Items)
            {
                sb.AppendLine($"{i.Prod.Name}, R${i.Prod.Price.ToString("F2", CultureInfo.InvariantCulture)}" +
                              $", Quantity: {i.Quantity}, SubTotal: {i.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine($"Total Price: R${Total()}");


            return sb.ToString();
        }
    }

}
