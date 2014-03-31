using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataLayer;
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
            using (var context = new MonsterContext())
            {
                var monsters = context.Monsters.Select(m => new MonsterJson {name = m.Name, price = m.Price}).ToList();

                return monsters;
            }
        }
    }
}