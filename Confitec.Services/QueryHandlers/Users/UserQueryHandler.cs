using Confitec.Core.Exceptions;
using Confitec.Infra.Contracts;
using Confitec.Services.Projections;
using Confitec.Services.QueryHandlers.Users.Contracts;
using Confitec.Services.QueryHandlers.Users.Queries;
using Confitec.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.QueryHandlers.Users
{
    public sealed class UserQueryHandler : IUserQueryHandler
    {
        private readonly IUserRepository _userRepository;
        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.ListAsQueryable().ToViewModel().ToList();
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsNoTrackingAsync(x => x.Id == request.Id);
            if (user is null) throw new DomainException("Usuário não encontrado");

            return user.ToViewModel();
        }
    }
}
