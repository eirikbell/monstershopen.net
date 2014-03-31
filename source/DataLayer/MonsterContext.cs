using System.Data.Entity;
using DataLayer.EntityMapping;
using DomainModel;

namespace DataLayer
{
    public class MonsterContext : DbContext
    {
        public MonsterContext()
            : base("Monster")
        {
            Database.SetInitializer<MonsterContext>(null);
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MonsterMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderLineMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
