using API_Client.Model;
using API_Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService _userService)
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
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                var result = await Task.Run(() => userService.UpdateUser(user));
                if(user is null) return NotFound("User not found");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("get/{id}")]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
