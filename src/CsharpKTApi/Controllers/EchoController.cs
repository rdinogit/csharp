using CsharpKTApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CsharpKTApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EchoController : ControllerBase
    {
        public EchoController()
        {
        }

        [HttpPost("echo", Name = "Echo")]
        public IActionResult PostEcho(string input)
        {
            return Ok(input);
        }

        [HttpPost("echo-object", Name = "EchoObject")]
        public IActionResult PostEchoObject(EchoRequestModel input)
        {
            return Ok(input);
        }
    }
}
