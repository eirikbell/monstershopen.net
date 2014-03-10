using System.Collections.Generic;
using System.Web.Http;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class MonsterTypesController : ApiController
    {
        /// <summary>
        /// Gets all available monster types
        /// </summary>
        /// <returns>Collection of monster types</returns>
        /// GET /service/monstertypes/
        [HttpGet]
        public IEnumerable<MonsterJson> Get()
        {
            return MosterTypeRepo.MonsterList;
        }
    }
}