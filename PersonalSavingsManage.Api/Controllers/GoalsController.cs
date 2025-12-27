using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;
using PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

namespace PersonalSavingsManage.Api.Controllers;

[Route("api/goals")]
[ApiController]
[Produces("application/json")]
public class GoalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GoalsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getAllGoalsQuery = new GetAllGoalsQuery();

        var goals = await _mediator.Send(getAllGoalsQuery);

        return Ok(goals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var getGoalByIdQuery = new GetGoalByIdQuery(id);

        var result = await _mediator.Send(getGoalByIdQuery);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateGoalCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.Data});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateGoalCommand command)
    {
        command.Id = id;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteGoalCommand(id);

        var result = await _mediator.Send(command);

        if(!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }

}
