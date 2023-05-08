using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Customer 
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }

        public Customer(int customerId, string name, int age, string adress)
        {
            CustomerId = customerId;
            Name = name;
            Age = age;
            Adress = adress;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
