using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Authentication.Queries.Login;

public record LoginQuery(
    LoginQueryRequestDTO loginDetails
   ): IRequest<ErrorOr<LoginQueryResponse>>;
