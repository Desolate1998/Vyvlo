using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Authentication.Commands.Register;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.user.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(x => x.user.Password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(x => x.user.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.user.LastName).NotEmpty().WithMessage("Last name cannot be empty");
    }
}
