using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Customer : IComparable<Customer>
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public Customer(int customerId, string name, string adress)
        {
            CustomerId = customerId;
            Name = name;
            Adress = adress;
        }

        public int CompareTo(Customer? other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
