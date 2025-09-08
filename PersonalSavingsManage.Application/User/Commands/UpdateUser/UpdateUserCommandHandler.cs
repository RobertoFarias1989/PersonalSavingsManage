using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel<Unit>>
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
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
               new Password(request.PasswordValue!));

            await _repository.UpdateAsync(user);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The User was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
