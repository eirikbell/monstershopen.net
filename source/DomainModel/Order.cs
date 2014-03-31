using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class Order : IObjectWithState
    {
        public Order()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            OrderLines = new List<OrderLine>();
        }

        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public void AddOrderLine(OrderLine orderLine)
        {
            orderLine.OrderId = OrderId;
            orderLine.Order = this;
            OrderLines.Add(orderLine);
        }

        public State State { get; set; }
    }
}
