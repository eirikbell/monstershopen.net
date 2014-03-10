using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class BasketController : MonsterShopController
    {
        public BasketController()
        {
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
            var ordreLinje = BasketItems.SingleOrDefault(ol => ol.name == name);

            if (ordreLinje == null)
            {
                var monster = Monsters.GetMonster(name);
                if (monster == null)
                    return BadRequest();

                ordreLinje = new BasketItemJson
                {
                    name = name,
                    number = 1,
                    price = monster.price
                };

                BasketItems.Add(ordreLinje);
            }
            else
            {
                ordreLinje.number++;
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
            var ordreLinje = BasketItems.SingleOrDefault(ol => ol.name == name);

            if (ordreLinje == null)
                return Ok();

            ordreLinje.number--;

            if (ordreLinje.number <= 0)
            {
                BasketItems.Remove(ordreLinje);
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
            return new BasketSumJson {sum = BasketItems.Sum(ol => ol.number*ol.price)};
        }
    }
}