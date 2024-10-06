using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
{
    public GetUserByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
