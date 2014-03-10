using System.Web.Http;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class AuthController : MonsterShopController
    {
        /// <summary>
        /// Logs in a user with provided name
        /// </summary>
        /// <param name="name">Name of the user to log in</param>
        /// <returns>Value indicating success</returns>
        /// POST /service/auth/login/{name}/
        [HttpPost]
        public IHttpActionResult LogIn(string name)
        {
            CurrentCustomer = name;

            return Ok();
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        /// <returns>Value indicating success</returns>
        /// POST /service/auth/logout/
        [HttpPost]
        public IHttpActionResult LogOut()
        {
            CurrentCustomer = null;
            return Ok();
        }

        /// <summary>
        /// Gets the current logged in customer
        /// </summary>
        /// <returns>The customer</returns>
        /// GET /service/auth/customer/
        [HttpGet]
        public CustomerJson Customer()
        {
            return new CustomerJson
            {
                customerName = CurrentCustomer
            };
        }
    }
}