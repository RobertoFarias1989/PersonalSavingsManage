using MediatR;

namespace PersonalSavingsManage.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{

    public string Id { get; set; }
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
