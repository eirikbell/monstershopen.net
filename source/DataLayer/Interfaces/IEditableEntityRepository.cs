using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IEditableEntityRepository<TEntity, in TEntityKeyType> : IEntityRepository<TEntity, TEntityKeyType>
        where TEntity : IObjectWithState
    {
        void InsertOrUpdateGraph(TEntity entityGraph);
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntityKeyType entityId);
        int Save();
    }
}