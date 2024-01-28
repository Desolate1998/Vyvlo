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
        RuleFor(x => x.Data.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(x => x.Data.Password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(x => x.Data.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.Data.LastName).NotEmpty().WithMessage("Last name cannot be empty");
    }
}
