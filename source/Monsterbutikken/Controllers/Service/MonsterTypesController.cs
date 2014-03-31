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
            using (IMonsterRepository repo = new MonsterRepository())
            {
                var monsters = repo.All;
                if (monsters != null)
                {
                    return monsters.Select(m => new MonsterJson {name = m.Name, price = m.Price}).ToList();
                }

                return new List<MonsterJson>();
            }
        }
    }
}