namespace Monsterbutikken.UnitTests.Fixtures
{
    public interface IFixtureObject<out T> where T : class
    {
        T CreateSut();
    }
}
