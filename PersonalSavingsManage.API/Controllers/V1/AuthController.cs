using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalSavingsManage.Application.Login.Commands;
using PersonalSavingsManage.Application.PasswordRecovery.Commands;

namespace PersonalSavingsManage.API.Controllers.V1;

[Route("api/v{version:apiVersion}/auth")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion(1)]
public class AuthController : ControllerBase
{
    readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a login's user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginUserCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(result.Message);

        return Ok(result);
    }

    /// <summary>
    /// Password Recovery
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("password-recovery/request")]
    public async Task<IActionResult> RequestPasswordRecovery(PasswordRecoveryRequestCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    /// <summary>
    /// Validate recovery code
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("password-recovery/validate")]
    public IActionResult ValidateRecoveryCode(ValidateRecoveryCodeCommand command)
    {
        var result = _mediator.Send(command);

        if (!result.Result.IsSuccess)
            return BadRequest(result.Result.IsSuccess);

        return NoContent();
    }

    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("password-recovery/change")]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.IsSuccess);

        return NoContent();
    }
}
