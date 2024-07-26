using BankApplication.Features.BankAccounts;
using BankApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
        public class BankAccountsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public BankAccountsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("type/{accountType}")]
            public async Task<IEnumerable<BankAccount>> RetrieveBankAccountsbyType(string accountType)
            {
                var query = new GetBankAccountsByTypeQuery(accountType);
                var result = await _mediator.Send(query);
                return result;
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> RetrieveSpecificBankAccount(int id)
            {
                var account = await _mediator.Send(new GetAccountByIdQuery(id));
                if (account == null)
                {
                return NotFound();
                }
                return Ok(account);
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateBankAccount(int id, [FromBody] UpdateBankAccountCommand command)
            {
                if (id != command.Id)
                {
                    return BadRequest("ID mismatch");
                }
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    
}
