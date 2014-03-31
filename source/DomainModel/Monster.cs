namespace DomainModel
{
    public class Monster : IObjectWithState
    {
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public State State { get; set; }
    }
}
