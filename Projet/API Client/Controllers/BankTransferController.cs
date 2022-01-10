using API_Client.Model;
using API_Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransferController : ControllerBase
    {
        private IBankTransferService bankTransfersService;
        public BankTransferController(IBankTransferService _bankTransfersService)
        {
            bankTransfersService = _bankTransfersService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankTransfer newbankTransfer)
        {
            try
            {
                var result = await Task.Run(() => bankTransfersService.AddBankTransfer(newbankTransfer));
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
                var bankTransfer = await Task.Run(() => bankTransfersService.GetBankTransfer(id));
                if (bankTransfer is null) return NotFound("Banktransfer not found");
                return Ok(bankTransfer);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("IbanList/{iban}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> GetbyIban(string iban)
        {
            try
            {
                var bankTransfer = await Task.Run(() => bankTransfersService.GetBankTransferByIban(iban));
                if (bankTransfer is null) return NotFound("Banktransfer not found");
                return Ok(bankTransfer);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("nameList/{name}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> GetbyName(string name)
        {
            try
            {
                var bankTransfer = await Task.Run(() => bankTransfersService.GetBankTransferByName(name));
                if (bankTransfer is null) return NotFound("Banktransfer not found");
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
                var bankTransfers = await Task.Run(() => bankTransfersService.GetAllBankTransfer());
                return Ok(bankTransfers);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
