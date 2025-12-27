using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;
using PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;
using PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;
using PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;
using PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

namespace PersonalSavingsManage.Api.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getAllTransactionsQuery = new GetAllTransactionsQuery();

        var transactions = await _mediator.Send(getAllTransactionsQuery);

        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var getTransactionByIdQuery = new GetTransactionByIdQuery(id);

        var result = await _mediator.Send(getTransactionByIdQuery);

        if(!result.IsSuccess)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateTransactionCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new {id = result.Data});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateTransactionCommand command)
    {
        command.Id = id;

        var result = await _mediator.Send(command);

        if(!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTransactionCommand(id);

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }
}
