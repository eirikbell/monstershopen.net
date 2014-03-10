using System;
using System.Collections.Generic;

namespace Monsterbutikken.Models
{
    public class OrderJson
    {
        public DateTime date { get; set; }
        public double sum { get; set; }
        public ICollection<OrderLineItemJson> orderLineItems { get; set; }
    }
}