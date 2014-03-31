using DomainModel;

namespace DataLayer.Contract
{
    public interface IMonsterRepository : IEntityRepository<Monster, int>
    {
        Monster FindByName(string monsterName);
    }
}
