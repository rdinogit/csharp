namespace CsharpKTApi.Providers
{
    public class JwtTokenSettings
    {
        public const string SectionName = nameof(JwtTokenSettings);
        public string Secret { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int ExpirationTimeInMinutes { get; init; }
    }
}
