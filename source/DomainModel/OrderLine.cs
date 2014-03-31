using System;

namespace DomainModel
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public string Name
        {
            get { return Monster != null ? Monster.Name : null; }
        }

        public double Sum
        {
            get { return Quantity*Price; }
        }

        public int MonsterId { get; set; }
        public virtual Monster Monster { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}