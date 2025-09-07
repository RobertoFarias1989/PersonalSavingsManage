using MediatR;
using Microsoft.Extensions.Caching.Memory;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class ValidateRecoveryCodeCommandHandler : IRequestHandler<ValidateRecoveryCodeCommand, ResultViewModel<Unit>>
{
    private readonly IMemoryCache _cache;

    public ValidateRecoveryCodeCommandHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<ResultViewModel<Unit>> Handle(ValidateRecoveryCodeCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"RecoveryCode: {request.EmailAddress}";

        if(!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
        {
            return Task.FromResult(ResultViewModel<Unit>.Error("User not found"));
        }

        return Task.FromResult(ResultViewModel<Unit>.Success(Unit.Value));
    }
}
