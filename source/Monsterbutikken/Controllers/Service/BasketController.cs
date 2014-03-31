using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataLayer.Contract;
using DataLayer.Interfaces;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class BasketController : MonsterShopController
    {
        private readonly IMonsterRepository _monsterRepository;

        public BasketController(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;

            if (BasketItems == null)
            {
                BasketItems = new List<BasketItemJson>();
            }
        }

        public static ICollection<BasketItemJson> BasketItems { get; set; }

        /// <summary>
        /// Gets the current state of a customers basket
        /// </summary>
        /// <returns>Collection of basket items for the monsters.</returns>
        /// GET /service/basket/
        [HttpGet]
        public IEnumerable<BasketItemJson> Get()
        {
            return BasketItems;
        }

        /// <summary>
        /// Adds a new monster of a specified type to the customers basket.
        /// If there is an existing basket item the number of monsters is incremented, otherwise a new order basket item is created.
        /// </summary>
        /// <param name="name">Name of the monstertype to be added</param>
        /// <returns>Value indicating success</returns>
        /// POST /service/basket/add/{name}/
        [HttpPost]
        public IHttpActionResult Add(string name)
        {
            var orderLine = BasketItems.SingleOrDefault(ol => ol.name == name);

            if (orderLine == null)
            {
                var monster = _monsterRepository.FindByName(name);
                if (monster == null)
                    return BadRequest();

                orderLine = new BasketItemJson
                {
                    name = name,
                    number = 1,
                    price = monster.Price
                };

                BasketItems.Add(orderLine);
            }
            else
            {
                orderLine.number++;
            }

            return Ok();
        }

        /// <summary>
        /// Removes a monster from the customers basket. If the resulting number of monsters reaches 0, the basket item is removed.
        /// </summary>
        /// <param name="name">Name of the monstertype to be removed</param>
        /// <returns>Value indicating success</returns>
        /// POST /service/basket/remove/{name}/
        [HttpPost]
        public IHttpActionResult Remove(string name)
        {
            var orderLine = BasketItems.SingleOrDefault(ol => ol.name == name);

            if (orderLine == null)
                return Ok();

            orderLine.number--;

            if (orderLine.number <= 0)
            {
                BasketItems.Remove(orderLine);
            }

            return Ok();
        }

        /// <summary>
        /// Calculates the sum of (price * number) for all items in the basket.
        /// </summary>
        /// <returns>Basket sum</returns>
        /// GET /service/basket/sum/
        [HttpGet]
        public BasketSumJson Sum()
        {
            return new BasketSumJson { sum = BasketItems.Sum(ol => ol.number * ol.price) };
        }
    }
}