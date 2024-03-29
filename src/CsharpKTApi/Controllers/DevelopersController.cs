using CsharpKT.ApiModels;
using CsharpKTApi.Mappers;
using CsharpKTApi.Models;
using CsharpKTApi.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace CsharpKTApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("create", Name = "CreateDeveloper")]
        [ProducesResponseType(typeof(Developer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostDeveloper(DeveloperRequestModel request)
        {
            var developer = _mapper.Map(request);
            return Ok(developer);
        }
    }
}
