using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }

        public Order(int orderId, int customerId, int quantity)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Quantity = quantity;
        }
    }
}
