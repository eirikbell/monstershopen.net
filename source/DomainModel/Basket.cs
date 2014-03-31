using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class Basket
    {
        public int BasketId { get; set; }

        public double Sum
        {
            get
            {
                if (BasketItems != null && BasketItems.Any())
                {
                    return BasketItems.Sum(bi => bi.Quantity*bi.Monster.Price);
                }
                return 0;
            }
        }

        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
