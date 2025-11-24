using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.Services;
using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _repository;
    readonly IAuthService _authService;

    public UpdateUserCommandHandler(IUserRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if (user != null && user.IsDeleted != true)
        {
            user.Update(
               new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),          
               new Email(request.EmailAddress!),
               new Name(request.FullName!),
               new Password(_authService.ComputeSha256Hash(request.PasswordValue!)));

            await _repository.UpdateAsync(user);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The User was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
