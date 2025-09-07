using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class ChangePasswordCommand : IRequest<ResultViewModel<Unit>>
{
    public string? EmailAddress { get; set; }
    public string? Code { get; set; }
    public string? NewPassword { get; set; }
}
