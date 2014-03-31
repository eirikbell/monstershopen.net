using DataLayer;
using DataLayer.Interfaces;
using DomainModel;
using Moq;
using NUnit.Framework;

namespace Monsterbutikken.UnitTests
{
    [TestFixture]
    public class MonsterRepositoryTests
    {
        [Test]
        public void TestFindByNameRetrievesCorrectMonster()
        {
            var monsterExpected = new Monster
            {
                MonsterId = 17,
                Name = "Expected name",
                Price = 100
            };

            var otherMonster = new Monster
            {
                MonsterId = 15,
                Name = "Different name",
                Price = 150
            };

            var monsterDbSet = new MonsterFakeDbSet {monsterExpected, otherMonster};

            var contextMock = new Mock<IMonsterContext>();
            contextMock.Setup(c => c.Monsters).Returns(monsterDbSet);

            var repo = new MonsterRepository(contextMock.Object);

            var result = repo.FindByName(monsterExpected.Name);

            Assert.AreSame(monsterExpected, result);
        }
    }
}
