using Asp.Versioning;
using CsharpKTApi.Models.v2;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CsharpKTApi.Controllers.v2
{
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        public DevelopersController()
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostDeveloper(DeveloperRequestModel request)
        {
            return NoContent();
        }
    }
}
