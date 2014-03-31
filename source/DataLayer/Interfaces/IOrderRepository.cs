using System;
using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository : IEditableEntityRepository<Order, Guid>
    {
    }
}
