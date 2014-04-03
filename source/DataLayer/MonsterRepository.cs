using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Contract;
using DataLayer.Interfaces;
using DomainModel;

namespace DataLayer
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly IMonsterContext _context;

        public MonsterRepository(IMonsterContext context)
        {
            _context = context;
        }

        public Monster Find(int entityId)
        {
            return _context.Monsters.Find(entityId);
        }

        public Monster FindByName(string monsterName)
        {
            return
                _context.Monsters.SingleOrDefault(
                    m => m.Name.Equals(monsterName, StringComparison.InvariantCultureIgnoreCase));
        }

        public ICollection<Monster> All
        {
            get { return _context.Monsters.ToList(); }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}