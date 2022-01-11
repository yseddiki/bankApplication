using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperviseurApi.Models.HelbModel;
using SuperviseurApi.Services.HelbService;

namespace SuperviseurApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelbAccountController : ControllerBase
    {
        private IAccountService accountService;
        public HelbAccountController(IAccountService _accountService)
        {
            accountService = _accountService;
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var bankTransfer = await Task.Run(() => accountService.GetAccount(id));
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
