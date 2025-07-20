using MediatR;
using PersonalSavingsManage.Application.Login.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Login.Commands;

public class LoginUserCommand : IRequest<ResultViewModel<LoginUserViewModel>>
{
    public string? EmailAddress { get; set; }
    public string? PasswordValue { get; set; }
}
