using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataLayer.Interfaces;
using DomainModel;

namespace DataLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MonsterContext _context;

        public OrderRepository()
        {
            _context = new MonsterContext();
        }

        private IQueryable<Order> Orders
        {
            get { return _context.Orders.Include(o => o.OrderLines.Select(ol => ol.Monster)); }
        }

        public Order Find(Guid entityId)
        {
            return Orders.SingleOrDefault(o => o.OrderId == entityId);
        }

        public ICollection<Order> All
        {
            get { return Orders.ToList(); }
        }

        public void InsertOrUpdateGraph(Order entityGraph)
        {
            InsertOrUpdate(entityGraph);

            foreach (var orderLine in entityGraph.OrderLines)
            {
                if (orderLine.OrderLineId == default(int))
                {
                    _context.Entry(orderLine).State = EntityState.Added;
                }
                else
                {
                    _context.OrderLines.Add(orderLine);

                    var state = StateHelpers.ConvertState(orderLine);

                    _context.Entry(orderLine).State = state;
                }
            }
        }

        public void InsertOrUpdate(Order entity)
        {
            if (entity.OrderId == default(Guid))
            {
                entity.OrderId = Guid.NewGuid();
                _context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _context.Orders.Add(entity);

                var state = StateHelpers.ConvertState(entity);

                _context.Entry(entity).State = state;
            }
        }

        public void Delete(Guid entityId)
        {
            var order = _context.Orders.Find(entityId);
            _context.Orders.Remove(order);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}