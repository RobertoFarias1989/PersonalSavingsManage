using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.Login.Commands;
using PersonalSavingsManage.Application.PasswordRecovery.Commands;
using PersonalSavingsManage.Application.User.Commands.CreateUser;
using PersonalSavingsManage.Application.User.Commands.DeleteUser;
using PersonalSavingsManage.Application.User.Queries.GetAllUsers;
using PersonalSavingsManage.Application.User.Queries.GetUserById;
using PersonalSavingsManage.Application.User.ViewModels;

namespace PersonalSavingsManage.API.Controllers.V1;

[Route("api/v{version:apiVersion}/users")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion(1)]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all the users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<UserViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var getAllUsersQuery = new GetAllUsersQuery();

        var users = await _mediator.Send(getAllUsersQuery);

        return Ok(users);
    }

    /// <summary>
    /// Get a user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);

        var user = await _mediator.Send(getUserByIdQuery);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    /// <summary>
    /// Create a user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }   

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand(id);

        var result = await _mediator.Send(command);

        if(!result.IsSuccess)
            return NotFound(result.Message);

        return NoContent();
    }
}
