using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperviseurApi.Models;
using SuperviseurApi.Services.HelbService;

namespace SuperviseurApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelbUserController : ControllerBase
    {
        private IUserService userService;
        public HelbUserController(IUserService _userService)
        {
            userService = _userService;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            try
            {
                var result = await Task.Run(() => userService.AddUser(newUser));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var bankTransfer = await Task.Run(() => userService.GetUser(id));
                if (bankTransfer is null) return NotFound("User not found");
                return Ok(bankTransfer);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var bankTransfers = await Task.Run(() => userService.GetAllUsers());
                return Ok(bankTransfers);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async void Delete(int id)
        {
            try
            {
                await Task.Run(() => userService.DeleteUser(id));
            }
            catch (ArgumentException ex)
            {
                StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
