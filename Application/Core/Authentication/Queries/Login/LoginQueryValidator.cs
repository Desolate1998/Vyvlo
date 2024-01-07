using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Data.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.Data.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
