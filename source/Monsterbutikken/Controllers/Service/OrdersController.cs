using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Monsterbutikken.Models;
using WebGrease.Css.Extensions;

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

            Orders.Add(Guid.NewGuid(), new OrderJson
            {
                date = DateTime.Now,
                sum = basketItems.Sum(ol => ol.number*ol.price),
                orderLineItems =
                    basketItems.Select(
                        item => new OrderLineItemJson {name = item.name, number = item.number, price = item.price}).ToList()
            });

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
            return Orders;
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
            return Orders[id];
        }
    }
}
