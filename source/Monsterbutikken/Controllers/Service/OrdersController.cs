using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using DataLayer;
using DomainModel;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class OrdersController : ApiController
    {
        public OrdersController()
        {
            if (Orders == null)
            {
                Orders = new Dictionary<Guid, OrderJson>();
            }
        }

        public static IDictionary<Guid, OrderJson> Orders { get; set; }

        /// <summary>
        /// Submits a new order for the current customer
        /// </summary>
        /// <returns>Value indicating success</returns>
        /// POST /service/orders/placeorder/
        [HttpPost]
        public IHttpActionResult PlaceOrder()
        {
            var basketItems = BasketController.BasketItems;

            using (var context = new MonsterContext())
            {
                var order = new Order
                {
                    OrderId = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Sum = basketItems.Sum(ol => ol.number*ol.price)
                };

                foreach (var basketItem in basketItems)
                {
                    var monster =
                        context.Monsters.SingleOrDefault(
                            m => m.Name.Equals(basketItem.name, StringComparison.InvariantCultureIgnoreCase));

                    if (monster != null)
                    {
                        var orderLine = new OrderLine
                                    {
                                        Price = basketItem.price,
                                        Quantity = basketItem.number,
                                        Monster = monster,
                                        MonsterId = monster.MonsterId
                                    };

                        order.AddOrderLine(orderLine); 
                    }
                    else
                    {
                        return Conflict();
                    }
                }

                context.Orders.Add(order);
                context.SaveChanges();
            }

            BasketController.BasketItems.Clear();

            return Ok();
        }

        /// <summary>
        /// Gets the current customers orders
        /// </summary>
        /// <returns>Dictionary of orders, where the key is the order-id and the value an order object.</returns>
        /// GET /service/orders/
        [HttpGet]
        public IDictionary<Guid, OrderJson> Get()
        {
            using (var context = new MonsterContext())
            {
                return context.Orders.Include(o => o.OrderLines.Select(ol => ol.Monster)).ToDictionary(o => o.OrderId,
                    o =>
                        new OrderJson
                        {
                            date = o.Date,
                            sum = o.Sum,
                            orderLineItems =
                                o.OrderLines.Select(
                                    ol => new OrderLineItemJson { name = ol.Name, number = ol.Quantity, price = ol.Price })
                                    .ToList()
                        });
            }

            //return Orders;
        }

        /// <summary>
        /// Gets a single order
        /// </summary>
        /// <param name="id">Identifier for the order to be retrieved</param>
        /// <returns>Order object</returns>
        /// GET /service/orders/{id}/
        [HttpGet]
        public OrderJson Get(Guid id)
        {
            using (var context = new MonsterContext())
            {
                var order =
                    context.Orders.Include(o => o.OrderLines.Select(ol => ol.Monster))
                        .FirstOrDefault(o => o.OrderId == id);

                if (order != null)
                {
                    return new OrderJson
                            {
                                date = order.Date,
                                sum = order.Sum,
                                orderLineItems = order.OrderLines.Select(ol => new OrderLineItemJson { name = ol.Name, number = ol.Quantity, price = ol.Price }).ToList()
                            }; 
                }

                return null;
            }
        }
    }
}
