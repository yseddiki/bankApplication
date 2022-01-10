using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperviseurApi.Models;
using SuperviseurApi.Models.HelbModel;
using SuperviseurApi.Services;

namespace SuperviseurApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelbAuthController : ControllerBase
    {
        private IHelbAuthenticationService authService;
        public HelbAuthController(IHelbAuthenticationService _authService)
        {
            authService = _authService;
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            try
            {
                var result = await Task.Run(() => authService.RetrieveToken(user));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
