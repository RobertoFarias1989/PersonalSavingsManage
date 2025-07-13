using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.User.Commands.CreateUser;
using PersonalSavingsManage.Application.User.Queries.GetUserById;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);

        var user = await _mediator.Send(getUserByIdQuery);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }
}
