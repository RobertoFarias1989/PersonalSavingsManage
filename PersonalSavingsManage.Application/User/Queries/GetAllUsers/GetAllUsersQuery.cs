using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;

namespace PersonalSavingsManage.Application.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{
}
