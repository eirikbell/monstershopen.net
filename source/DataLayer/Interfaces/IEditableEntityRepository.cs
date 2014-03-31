using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IEditableEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : IObjectWithState
    {
        void InsertOrUpdateGraph(TEntity entityGraph);
        void InsertOrUpdate(TEntity entity);
        void Delete(int entityId);
        int Save();
    }
}