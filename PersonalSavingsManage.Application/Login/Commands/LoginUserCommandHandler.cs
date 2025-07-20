using MediatR;
using PersonalSavingsManage.Application.Login.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.Services;

namespace PersonalSavingsManage.Application.Login.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Utilizar o mesmo algoritmo para criar o hash dessa senha
        var passwordHash = _authService.ComputeSha256Hash(request.PasswordValue!);

        //Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.EmailAddress!, passwordHash);

        //Se não existir, erro no login
        if (user == null)
            return ResultViewModel<LoginUserViewModel>.Error("The User could not be found");

        //Se existir, gero o token usando os dados do usuário
        var token = _authService.GenerateJwtToken(user.Email.EmailAddress, user.Role);

        return ResultViewModel<LoginUserViewModel>.Success(new LoginUserViewModel(user.Email.EmailAddress, token));
    }
}
