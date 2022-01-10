using API_Client.Interfaces;
using API_Client.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService accountService;
        public AccountController(IAccountService _AccountService)
        {
            accountService = _AccountService;
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            try
            {
                var result = await Task.Run(() => accountService.AddAccount(account));
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
                var account = await Task.Run(() => accountService.GetAccount(id));
                if (account is null) return NotFound("Account not found");
                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("list")]
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> List()
        {
            try
            {
                var bankTransfers = await Task.Run(() => accountService.GetAllAccounts());
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
                await Task.Run(() => accountService.Delete(id));    
            }
            catch (ArgumentException ex)
            {
                StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
