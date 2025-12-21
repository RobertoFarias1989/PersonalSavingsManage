using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
