using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Core.Entities.User(
            new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),
            new Email(request.EmailAddress!),
            new Name(request.FullName!),
            new Password(request.PasswordValue!),
            request.Role!);

        await _repository.Addasync(user);

        return ResultViewModel<int>.Success(user.Id);
    }
}
