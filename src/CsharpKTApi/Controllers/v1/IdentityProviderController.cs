using CsharpKTApi.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CsharpKTApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityProviderController : ControllerBase
    {
        private readonly IJwtTokenProvider _tokenProvider;

        public IdentityProviderController(IJwtTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken(string email, string password)
        {
            // validate email
            // validate password

            var token = await _tokenProvider.GenerateTokenAsync(email);
            return Ok(token);
        }
    }
}
