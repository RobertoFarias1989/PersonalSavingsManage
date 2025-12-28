using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.User.Commands.CreateUser;
using PersonalSavingsManage.Application.User.Commands.DeleteUser;
using PersonalSavingsManage.Application.User.Commands.UpdateUser;
using PersonalSavingsManage.Application.User.Queries.GetAllUsers;
using PersonalSavingsManage.Application.User.Queries.GetUserById;

namespace PersonalSavingsManage.Api.Controllers;

[Route("api/users")]
[ApiController]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getAllUsersQuery = new GetAllUsersQuery();

        var users = await _mediator.Send(getAllUsersQuery);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);

        var result = await _mediator.Send(getUserByIdQuery);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.Data });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateUserCommand command)
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
        var deleteUserCommand = new DeleteUserCommand(id);

        var result = await _mediator.Send(deleteUserCommand);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }
}
