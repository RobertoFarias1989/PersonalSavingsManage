using MediatR;
using Microsoft.Extensions.Caching.Memory;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class PasswordRecoveryRequestCommandHandler : IRequestHandler<PasswordRecoveryRequestCommand, ResultViewModel<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _cache;

    public PasswordRecoveryRequestCommandHandler(IUserRepository userRepository, IMemoryCache cache)
    {
        _userRepository = userRepository;
        _cache = cache;
    }

    public async Task<ResultViewModel<Unit>> Handle(PasswordRecoveryRequestCommand request, CancellationToken cancellationToken)
    {
        var user  = await _userRepository.GetUserByEmailAsync(request.EmailAddress!);

        if(user == null)
            return ResultViewModel<Unit>.Error("User not found");

        var code = new Random().Next(100000, 999999).ToString();

        var cacheKey = $"RecoveryCode: {request.EmailAddress}";

        _cache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

        //TODO:implementar o envio de email

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
