using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Interfaces;
using DomainModel;

namespace DataLayer
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly MonsterContext _context;

        public MonsterRepository()
        {
            _context = new MonsterContext();
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