using System.Data.Entity;
using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IMonsterContext : IContext
    {
         IDbSet<Monster> Monsters { get; }
         IDbSet<Order> Orders { get; }
         IDbSet<OrderLine> OrderLines { get; }
    }
}
