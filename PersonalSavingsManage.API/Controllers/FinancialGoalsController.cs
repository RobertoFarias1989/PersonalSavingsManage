using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.API.Controllers;

[Route("api/financial-goals")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
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
    [ProducesResponseType(typeof(List<FinancialGoalViewModel>),StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(FinancialGoalViewModel),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new GetFinacialGoalByIdQuery(id);

        var financialGoal = await _mediator.Send(query);

        if(financialGoal == null)
        {
            return NotFound();
        }

        return Ok(financialGoal);
    }

    /// <summary>
    /// Create a financial goal
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateFinancialGoalCommand),StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(CreateFinancialGoalCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    /// <summary>
    /// Update a financial goal
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateFinancialGoalCommand),StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(string id, UpdateFinancialGoalCommand command)
    {
        await _mediator.Send(command);
  
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
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteFinancialGoalCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
