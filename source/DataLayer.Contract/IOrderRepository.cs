using System;
using DomainModel;

namespace DataLayer.Contract
{
    public interface IOrderRepository : IEditableEntityRepository<Order, Guid>
    {
    }
}
