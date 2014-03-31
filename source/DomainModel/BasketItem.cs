namespace DomainModel
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }

        public int MonsterId { get; set; }
        public Monster Monster { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}