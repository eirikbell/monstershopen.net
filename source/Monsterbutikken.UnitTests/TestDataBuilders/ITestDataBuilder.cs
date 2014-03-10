namespace Monsterbutikken.UnitTests.TestDataBuilders
{
    public interface ITestDataBuilder<out T> where T : class
    {
        T Build();
    }
}