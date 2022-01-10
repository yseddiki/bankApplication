
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperviseurApi.Models.HelbModel;
using SuperviseurApi.Services.HelbService;

namespace SuperviseurApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelbBankTransfersController : ControllerBase
    {
        private IBankTransferService bankTransferService;
        public HelbBankTransfersController(IBankTransferService _bankTransferService)
        {
            bankTransferService = _bankTransferService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankTransfer bankTransfer)
        {
            try
            {
                var result = await Task.Run(() => bankTransferService.AddBankTransfer(bankTransfer));
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
                var bankTransfer = await Task.Run(() => bankTransferService.GetBankTransfer(id));
                if (bankTransfer is null) return NotFound("BankTransfer not found");
                return Ok(bankTransfer);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("IbanList/{iban}")]
        public async Task<IActionResult> GetBankTransferByIban(string iban)
        {
            try
            {
                var bankTransfer = await Task.Run(() => bankTransferService.GetBankTransferByIban(iban));
                if (bankTransfer is null) return NotFound("BankTransfer not found");
                return Ok(bankTransfer);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("nameList/{name}")]
        public async Task<IActionResult> GetBankTransferByName(string name)
        {
            try
            {
                var bankTransfer = await Task.Run(() => bankTransferService.GetBankTransferByName(name));
                if (bankTransfer is null) return NotFound("BankTransfer not found");
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
                var bankTransfers = await Task.Run(() => bankTransferService.GetAllBankTransfers());
                return Ok(bankTransfers);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
