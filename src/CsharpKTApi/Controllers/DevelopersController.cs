using CsharpKTApi.Mappers;
using CsharpKTApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CsharpKTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private IDeveloperMapper _mapper;

        public DevelopersController(IDeveloperMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost(Name = "CreateDeveloper")]
        public IActionResult PostDeveloper(DeveloperRequestModel request)
        {
            var developer = _mapper.Map(request);
            return Ok(developer);
        }
    }
}
