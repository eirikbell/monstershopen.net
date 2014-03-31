using System.Linq;
using DomainModel;

namespace Monsterbutikken.UnitTests
{
    public class MonsterFakeDbSet : FakeDbSet<Monster>
    {
        public override Monster Find(params object[] keyValues)
        {
            var id = (int)keyValues.First();
            return List.Find(f => f.MonsterId == id);
        }
    }
}