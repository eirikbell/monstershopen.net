using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IMonsterRepository : IEntityRepository<Monster, int>
    {
        Monster FindByName(string monsterName);
    }
}
