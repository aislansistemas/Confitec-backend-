using Confitec.Services.ViewModels;
using MediatR;
using System.Text.Json.Serialization;

namespace Confitec.Services.Handles.Users.Commands
{
    public sealed class DeleteUserCommand : IRequest<UserViewModel>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
