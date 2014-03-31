using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            OrderLines = new List<OrderLine>();
        }

        [Column("OrderGuid")]
        [Key]
        public Guid OrderId { get; set; }

        [Column("OrderDate")]
        public DateTime Date { get; set; }

        [Column("Sum")]
        public double Sum { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public void AddOrderLine(OrderLine orderLine)
        {
            orderLine.OrderId = OrderId;
            orderLine.Order = this;
            OrderLines.Add(orderLine);
        }
    }
}
