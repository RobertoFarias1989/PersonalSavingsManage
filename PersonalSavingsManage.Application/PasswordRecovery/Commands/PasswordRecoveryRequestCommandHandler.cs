using MediatR;
using Microsoft.Extensions.Caching.Memory;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Infrastructure.Notifications;

namespace PersonalSavingsManage.Application.PasswordRecovery.Commands;

public class PasswordRecoveryRequestCommandHandler : IRequestHandler<PasswordRecoveryRequestCommand, ResultViewModel<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _cache;
    private readonly IEmailService _emailService;

    public PasswordRecoveryRequestCommandHandler(IUserRepository userRepository, IMemoryCache cache, IEmailService emailService)
    {
        _userRepository = userRepository;
        _cache = cache;
        _emailService = emailService;
    }

    public async Task<ResultViewModel<Unit>> Handle(PasswordRecoveryRequestCommand request, CancellationToken cancellationToken)
    {
        var user  = await _userRepository.GetUserByEmailAsync(request.EmailAddress!);

        if(user == null)
            return ResultViewModel<Unit>.Error("User not found");

        var code = new Random().Next(100000, 999999).ToString();

        var cacheKey = $"RecoveryCode: {request.EmailAddress}";

        _cache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

        await _emailService.SendAsync(user.Email.EmailAddress, "Código de Recuperação", $"Seu código de recuperação é: {code}");

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
