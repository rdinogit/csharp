namespace CsharpKTApi.Providers
{
    public interface IDateTimeProvider
    {
        DateTimeOffset UtcNow { get; }
    }
}
