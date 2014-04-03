using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataLayer;
using DataLayer.Interfaces;
using DomainModel;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class OrdersController : ApiController
    {
        /// <summary>
        /// Submits a new order for the current customer
        /// </summary>
        /// <returns>Value indicating success</returns>
        /// POST /service/orders/placeorder/
        [HttpPost]
        public IHttpActionResult PlaceOrder()
        {
            var basketItems = BasketController.BasketItems;

            using (IOrderRepository repo = new OrderRepository())
            {
                using (IMonsterRepository monsterRepo = new MonsterRepository())
                {
                    var order = new Order
                            {
                                OrderId = Guid.NewGuid(),
                                Date = DateTime.Now,
                                Sum = basketItems.Sum(ol => ol.number * ol.price),
                                State = State.Added
                            };

                    foreach (var basketItem in basketItems)
                    {
                        var monster = monsterRepo.FindByName(basketItem.name);

                        if (monster != null)
                        {
                            var orderLine = new OrderLine
                            {
                                Price = basketItem.price,
                                Quantity = basketItem.number,
                                Monster = monster,
                                MonsterId = monster.MonsterId,
                                State = State.Added
                            };

                            order.AddOrderLine(orderLine);
                        }
                        else
                        {
                            return Conflict();
                        }
                    }

                    repo.InsertOrUpdateGraph(order);
                    repo.Save();
                }
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
            using (IOrderRepository repo = new OrderRepository())
            {
                var orders = repo.All;

                if (orders != null)
                {
                    return orders.ToDictionary(o => o.OrderId,
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

                return new Dictionary<Guid, OrderJson>();
            }
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
            using (IOrderRepository repo = new OrderRepository())
            {
                var order = repo.Find(id);

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
