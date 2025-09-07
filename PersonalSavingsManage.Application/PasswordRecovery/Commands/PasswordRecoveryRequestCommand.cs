using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class PasswordRecoveryRequestCommand : IRequest<ResultViewModel<Unit>>
{
    public string? EmailAddress { get; set; }
}
