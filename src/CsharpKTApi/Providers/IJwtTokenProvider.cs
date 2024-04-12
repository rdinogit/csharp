namespace CsharpKTApi.Providers
{
    public interface IJwtTokenProvider
    {
        Task<string> GenerateTokenAsync(string email);
    }
}
