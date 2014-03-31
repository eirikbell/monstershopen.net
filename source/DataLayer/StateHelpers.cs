using System.Data.Entity;
using DomainModel;

namespace DataLayer
{
    public static class StateHelpers
    {
        public static EntityState ConvertState(IObjectWithState entity)
        {
            return ConvertState(entity.State);
        }

        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}