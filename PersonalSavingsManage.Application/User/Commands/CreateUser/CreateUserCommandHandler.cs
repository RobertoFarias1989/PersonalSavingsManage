using MediatR;
using Microsoft.AspNetCore.Identity;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.Services;
using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Core.Entities.User(
            new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),
            new Email(request.EmailAddress!),
            new Name(request.FullName!),
            new Password(_authService.ComputeSha256Hash(request.PasswordValue!)),
            request.Role!);

        await _repository.AddAsync(user);

        return user.Id;
    }
}
