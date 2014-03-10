using System.Web.Http;

namespace Monsterbutikken.Controllers.Service
{
    public abstract class MonsterShopController : ApiController
    {
        protected static string CurrentCustomer { get; set; }

        protected void LogoutCurrentCustomer()
        {
            CurrentCustomer = null;
        }
    }
}