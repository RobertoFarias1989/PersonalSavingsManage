using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class ValidateRecoveryCodeCommand : IRequest<ResultViewModel<Unit>>
{
    public string? EmailAddress { get; set; }
    public string? Code { get; set; }
}
