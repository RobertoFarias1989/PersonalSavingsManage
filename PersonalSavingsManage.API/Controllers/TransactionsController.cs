using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;
using PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;
using PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;
using PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;
using PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.API.Controllers;

[Route("api/transactions")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all the transactions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<TransactionViewModel>),StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllTransactionsQuery();

        var transactions = await _mediator.Send(query);

        return Ok(transactions);
    }

    /// <summary>
    /// Get a transaction by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TransactionDetailsViewModel),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new GetTransactionByIdQuery(id);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }

    /// <summary>
    /// Create a transaction
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateTransactionCommand),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateTransactionCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Data}, command);
    }

    /// <summary>
    /// Update a transaction
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateTransactionCommand),StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(string id, UpdateTransactionCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }

    /// <summary>
    /// Delete a transaction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteTransactionCommand(id);

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }

}
