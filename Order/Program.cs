using System;
using System.Globalization;
using Order.Entities;
using Order.Entities.Enum;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client name");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Email: ");
            string Email = Console.ReadLine();
            Console.Write("Bitrh Date: ");
            DateTime BirthDate = DateTime.Parse(Console.ReadLine());

            Client C = new Client(Name, Email, BirthDate);

            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            OrderStatus os = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int N = int.Parse(Console.ReadLine());

            Order Order = new Order(DateTime.Now, os, C);

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Enter #{i} item:");
                Console.Write("Product Name: ");
                string ProductName = Console.ReadLine();
                Console.Write("Product Price: ");
                double ProductPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int Quantity = int.Parse(Console.ReadLine());

                Product product = new Product(ProductName, ProductPrice);
                OrderItem Oi = new OrderItem(Quantity, product);

                Order.AddItem(Oi);
            }

            Console.WriteLine(Order);
        }
    }
}