using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ResultViewModel<Unit>>
{

    public Guid Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? EmailAddress { get; set; }
    public string? FullName { get; set; }
    public string? PasswordValue { get; set; }
    public string? Role { get; set; }
}
