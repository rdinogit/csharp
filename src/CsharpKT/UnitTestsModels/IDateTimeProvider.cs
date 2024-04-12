namespace CsharpKT.UnitTestsModels
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}