using System.Data.Entity;
using DataLayer.EntityMapping;
using DataLayer.Interfaces;
using DomainModel;

namespace DataLayer
{
    public class MonsterContext : DbContext, IMonsterContext
    {
        public MonsterContext()
            : base("Monster")
        {
            Database.SetInitializer<MonsterContext>(null);
        }

        public IDbSet<Monster> Monsters { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MonsterMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderLineMapping());
            base.OnModelCreating(modelBuilder);
        }

        public void SetState(object entity, State state)
        {
            Entry(entity).State = StateHelpers.ConvertState(state);
        }

        public void SetAdded(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
