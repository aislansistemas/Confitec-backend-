using Confitec.Services.Handles.Users.Commands;
using Confitec.Services.ViewModels;
using MediatR;

namespace Confitec.Services.Handles.Users.Contracts
{
    public interface IUserHandler : IRequestHandler<CreateUserCommand, UserViewModel>,
        IRequestHandler<EditUserCommand, UserViewModel>,
        IRequestHandler<DeleteUserCommand, UserViewModel>
    {
    }
}
