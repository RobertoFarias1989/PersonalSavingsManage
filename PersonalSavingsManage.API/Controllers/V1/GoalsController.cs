using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateTransaction;
using PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteTransaction;
using PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateTransaction;

namespace PersonalSavingsManage.API.Controllers.V1;

[Route("api/v{version:apiVersion}/users/{userId}/goals")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion(1)]
public class GoalsController : ControllerBase
{
    readonly IMediator _mediator;

    public GoalsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add a transaction to a financial goal
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="goalId"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("{goalId}/transactions")]
    [ProducesResponseType(typeof(CreateTransactionToGoalCommand), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAddTransaction(Guid userId, Guid goalId, CreateTransactionToGoalCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }

    /// <summary>
    /// Update a transaction to specific financial goal
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="goalId"></param>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{goalId}/transactions/{id}")]
    [ProducesResponseType(typeof(UpdateTransactionToGoalCommand), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutTransaction(Guid userId, Guid goalId, Guid id, UpdateTransactionToGoalCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);


        return NoContent();
    }

    /// <summary>
    /// Delete  a transaction from specific financial goal
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="goalId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{goalId}/transactions/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTransaction(Guid userId, Guid goalId, Guid id)
    {
        var command = new DeleteTransactionToGoalCommand(userId, goalId, id);

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);


        return NoContent();
    }
}
