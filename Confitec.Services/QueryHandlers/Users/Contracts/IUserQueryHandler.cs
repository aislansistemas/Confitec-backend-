using Confitec.Services.QueryHandlers.Users.Queries;
using Confitec.Services.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Confitec.Services.QueryHandlers.Users.Contracts
{
    public interface IUserQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<UserViewModel>>,
         IRequestHandler<GetUserQuery, UserViewModel>
    {

    }
}
