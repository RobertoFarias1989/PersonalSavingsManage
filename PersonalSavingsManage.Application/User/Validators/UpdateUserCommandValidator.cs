using FluentValidation;
using PersonalSavingsManage.Application.User.Commands.UpdateUser;

namespace PersonalSavingsManage.Application.User.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.FullName)
           .NotEmpty()
               .WithMessage("FullName's field mustn't be empty.")
           .NotNull()
               .WithMessage("FullName's field mustn't be null.")
           .MaximumLength(150)
               .WithMessage("FullName's maximum length is around 150 characters.");

        RuleFor(u => u.PasswordValue)
            .NotEmpty()
                .WithMessage("PasswordValue's field mustn't be empty.")
            .NotNull()
                .WithMessage("PasswordValue's field mustn't be null.")
            .MaximumLength(100)
                .WithMessage("PasswordValue's maximum length is around 100 characters.");

        RuleFor(u => u.Role)
            .NotEmpty()
                .WithMessage("Role's field mustn't be empty.")
            .NotNull()
                .WithMessage("Role's field mustn't be null.")
            .MaximumLength(100)
                .WithMessage("Role's maximum length is around 100 characters.");


        RuleFor(u => u.EmailAddress)
        .NotEmpty()
           .WithMessage("EmailAddress's field mustn't be empty.")
       .NotNull()
           .WithMessage("EmailAddress's field mustn't be null.")
       .EmailAddress()
           .WithMessage("A valid email address is required.")
       .MaximumLength(100)
           .WithMessage("EmailAddress's maximum length is around 100 characters.");

        RuleFor(u => u.Street)
        .NotEmpty()
           .WithMessage("Street's field mustn't be empty.")
       .NotNull()
           .WithMessage("Street's field mustn't be null.")
       .MaximumLength(100)
           .WithMessage("Street's maximum length is around 100 characters.");

        RuleFor(u => u.City)
           .NotEmpty()
              .WithMessage("City's field mustn't be empty.")
          .NotNull()
              .WithMessage("City's field mustn't be null.")
          .MaximumLength(100)
              .WithMessage("City's maximum length is around 100 characters.");

        RuleFor(u => u.State)
           .NotEmpty()
              .WithMessage("State's field mustn't be empty.")
           .NotNull()
              .WithMessage("State's field mustn't be null.")
           .MaximumLength(100)
              .WithMessage("State's maximum length is around 100 characters.");

        RuleFor(u => u.PostalCode)
            .NotEmpty()
               .WithMessage("PostalCode's field mustn't be empty.")
            .NotNull()
               .WithMessage("PostalCode's field mustn't be null.")
            .MaximumLength(100)
               .WithMessage("PostalCode's maximum length is around 100 characters.");

        RuleFor(u => u.Country)
            .NotEmpty()
               .WithMessage("Country's field mustn't be empty.")
            .NotNull()
               .WithMessage("Country's field mustn't be null.")
            .MaximumLength(50)
               .WithMessage("Country's maximum length is around 50 characters.");
    }
}
