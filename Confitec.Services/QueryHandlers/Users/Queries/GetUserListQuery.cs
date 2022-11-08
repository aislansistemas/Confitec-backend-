using Confitec.Services.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Confitec.Services.QueryHandlers.Users.Queries
{
    public sealed class GetUserListQuery : IRequest<IEnumerable<UserViewModel>>
    {
    }
}
