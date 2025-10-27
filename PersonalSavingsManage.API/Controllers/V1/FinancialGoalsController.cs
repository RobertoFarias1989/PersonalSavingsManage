using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.API.Controllers.V1;

[Route("api/v{version:apiVersion}/financial-goals")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion(1)]
public class FinancialGoalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FinancialGoalsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Get all the financial goals
    /// </summary>
    /// <returns>A list of FinancialGoalViewModel</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<FinancialGoalViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var getAllFinacialGoalsQuery = new GetAllFinacialGoalsQuery();

        var financialGoals = await _mediator.Send(getAllFinacialGoalsQuery);

        return Ok(financialGoals);
    }

    /// <summary>
    /// Get the financial goal by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FinancialGoalViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetFinacialGoalByIdQuery(id);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return NotFound(result.Message);


        return Ok(result);
    }

    /// <summary>
    /// Create a financial goal
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(CreateFinancialGoalCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromForm] CreateFinancialGoalCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    /// <summary>
    /// Update a financial goal
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(UpdateFinancialGoalCommand), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(Guid id, [FromForm] UpdateFinancialGoalCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);


        return NoContent();
    }

    /// <summary>
    /// Delete a financial goal
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteFinancialGoalCommand(id);

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);


        return NoContent();
    }
}
