using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataLayer.Interfaces;
using Monsterbutikken.Models;

namespace Monsterbutikken.Controllers.Service
{
    public class MonsterTypesController : ApiController
    {
        private readonly IMonsterRepository _monsterRepository;

        public MonsterTypesController(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        /// <summary>
        /// Gets all available monster types
        /// </summary>
        /// <returns>Collection of monster types</returns>
        /// GET /service/monstertypes/
        [HttpGet]
        public IEnumerable<MonsterJson> Get()
        {
            var monsters = _monsterRepository.All;
            if (monsters != null)
            {
                return monsters.Select(m => new MonsterJson { name = m.Name, price = m.Price }).ToList();
            }

            return new List<MonsterJson>();
        }
    }
}