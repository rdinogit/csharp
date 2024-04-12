using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CsharpKTApi.Providers
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly JwtTokenSettings _settings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenProvider(
            IOptions<JwtTokenSettings> settings,
            IDateTimeProvider dateTimeProvider)
        {
            _settings = settings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public Task<string> GenerateTokenAsync(string email)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var now = _dateTimeProvider.UtcNow.UtcDateTime;

            var securityToken = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                expires: now.AddMinutes(_settings.ExpirationTimeInMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(securityToken));
        }
    }
}
