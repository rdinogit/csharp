using Asp.Versioning;
using CsharpKT.ApiModels;
using CsharpKTApi.Mappers;
using CsharpKTApi.Models.v1;
using CsharpKTApi.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace CsharpKTApi.Controllers.v1
{
    [Authorize]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private IDeveloperMapper _mapper;
        private TeamTypologySettings _teamSettings;

        public DevelopersController(
            IDeveloperMapper mapper,
            IOptionsSnapshot<TeamTypologySettings> teamSettings)
        {
            _mapper = mapper;
            _teamSettings = teamSettings.Value;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Developer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostDeveloper(DeveloperRequestModel request)
        {
            var developer = _mapper.Map(request);
            return Ok(developer);
        }
    }
}
