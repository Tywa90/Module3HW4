using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                       where c.CustomerId > 5
                       orderby c.CustomerId
                       select c;
            foreach (var customer in selected1)
            {
                Console.WriteLine(customer.Name);
            }

            var selected2 = from c in Customers
                           where c.CustomerId > 5
                           orderby c.Name
                           select c.CustomerId + " " + c.Name;
            foreach (var customer in selected2)
            {
                Console.WriteLine(customer);
            }
        }

        private void AddCustomer()
        {
            Customers.Add(new Customer(1, "David", "Lviv"));
            Customers.Add(new Customer(2, "Boris", "Kyiv"));
            Customers.Add(new Customer(3, "Denis", "Poltava"));
            Customers.Add(new Customer(4, "Anna", "Kharkiv"));
            Customers.Add(new Customer(5, "Evgen", "Kyiv"));
            Customers.Add(new Customer(6, "Taras", "Kramatorsk"));
            Customers.Add(new Customer(7, "Stanislav", "Oleksandriya"));
            Customers.Add(new Customer(8, "Alex", "Lviv"));
            Customers.Add(new Customer(9, "Anton", "Kyiv"));
        }

        private void AddOrder()
        {
            Orders.Add(new Order(10312, 5, 13));
            Orders.Add(new Order(10313, 4, 2));
            Orders.Add(new Order(10314, 1, 5));
            Orders.Add(new Order(10315, 8, 21));
            Orders.Add(new Order(10316, 9, 1));
            Orders.Add(new Order(10317, 2, 3));
            Orders.Add(new Order(10318, 3, 14));
            Orders.Add(new Order(10319, 7, 5));
            Orders.Add(new Order(10320, 6, 18));
            Orders.Add(new Order(10321, 1, 2));
        }
    }
}
