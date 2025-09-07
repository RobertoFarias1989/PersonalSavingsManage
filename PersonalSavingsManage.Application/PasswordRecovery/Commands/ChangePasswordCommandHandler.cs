using MediatR;
using Microsoft.Extensions.Caching.Memory;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.Services;
using PersonalSavingsManage.Core.ValueObjects;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _cache;
    private readonly IAuthService _authService;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IMemoryCache cache, IAuthService authService)
    {
        _userRepository = userRepository;
        _cache = cache;
        _authService = authService;
    }

    public async Task<ResultViewModel<Unit>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"RecoveryCode: {request.EmailAddress}";

        if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
        {
            return ResultViewModel<Unit>.Error("User not found");
        }

        _cache.Remove(cacheKey);

        var user = await _userRepository.GetUserByEmailAsync(request.EmailAddress!);

        if (user == null)
            return ResultViewModel<Unit>.Error("User not found");

        var hash = _authService.ComputeSha256Hash(request.NewPassword!);

        user.UpdatePassword(new Password(hash));

        await _userRepository.UpdateAsync(user);

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
