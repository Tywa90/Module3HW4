using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Task2Linq
    {
        public List<Customer> Customers { get; private set; }
        public List<Order> Orders { get; private set; }

        public Task2Linq()
        {
            Customers = new List<Customer>();
            Orders = new List<Order>();
        }

        public void Run()
        {
            AddCustomer();
            AddOrder();

            var selected1 = from c in Customers
                            where c.Age >= 18
                            orderby c.CustomerId
                            select c;

            if (selected1.All(c => c.Age >= 18))
            {
                Console.WriteLine("Adults customers");
            }
            else
            {
                Console.WriteLine("Not all customers are adults");
            }

            foreach (var customer in selected1)
            {
                Console.WriteLine(customer.Name);
            }

            Console.WriteLine("\nAll customers from Kyiv: ");
            var selected2 = from c in Customers
                            where c.Adress == "Kyiv"
                            orderby c.Name descending
                            select c.CustomerId + " " + c.Name + " " + c.Adress;
            foreach (var customer in selected2)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("\nFirst Customer in ages from 20 to 30 years: ");
            var selected3 = Customers
                .FirstOrDefault(c => c.Age > 20 && c.Age < 30);
            Console.WriteLine(selected3);

            Console.WriteLine("\nJoin tables Customer & Order:");
            var result = Customers
                .Join(Orders,
                c => c.CustomerId,
                ord => ord.CustomerId,
                (c, ord) => new
                {
                    CustomerId = ord.CustomerId,
                    Name = c.Name,
                    OrderId = ord.OrderId,
                    Quantity = ord.Quantity
                })
                .Where(c => c.Quantity > 10)
                .OrderBy(o => o.OrderId);

            foreach (var item in result)
            {
                Console.WriteLine($"OrderID: {item.OrderId} Quantity: {item.Quantity} Customer: {item.Name} ");
            }

            Console.WriteLine("\nGroup orders by Customer name: ");
            var groups = Customers
                .Join(Orders,
                c => c.CustomerId,
                ord => ord.CustomerId,
                (c, ord) => new
                {
                    CustomerId = ord.CustomerId,
                    Name = c.Name,
                    OrderId = ord.OrderId,
                })
                .GroupBy(c => c.Name);
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var customer in group)
                {
                    Console.WriteLine($"\t{customer.OrderId}");
                }
            }
        }

        private void AddCustomer()
        {
            Customers.Add(new Customer(1, "David", 18, "Lviv"));
            Customers.Add(new Customer(2, "Boris", 21, "Kyiv"));
            Customers.Add(new Customer(3, "Denis", 33, "Poltava"));
            Customers.Add(new Customer(4, "Anna", 17, "Kharkiv"));
            Customers.Add(new Customer(5, "Evgen", 16, "Kyiv"));
            Customers.Add(new Customer(6, "Taras", 35, "Kramatorsk"));
            Customers.Add(new Customer(7, "Stanislav", 31, "Oleksandriya"));
            Customers.Add(new Customer(8, "Alex", 22, "Lviv"));
            Customers.Add(new Customer(9, "Anton", 18, "Kyiv"));
        }

        private void AddOrder()
        {
            Orders.Add(new Order(10312, 5, 13));
            Orders.Add(new Order(10313, 4, 2));
            Orders.Add(new Order(10314, 3, 15));
            Orders.Add(new Order(10315, 8, 21));
            Orders.Add(new Order(10316, 9, 1));
            Orders.Add(new Order(10317, 2, 3));
            Orders.Add(new Order(10318, 3, 14));
            Orders.Add(new Order(10319, 3, 2));
            Orders.Add(new Order(10320, 6, 18));
            Orders.Add(new Order(10321, 1, 2));
        }
    }
}
