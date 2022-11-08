using Confitec.Services.ViewModels;
using MediatR;
using System.Text.Json.Serialization;

namespace Confitec.Services.QueryHandlers.Users.Queries
{
    public sealed class GetUserQuery : IRequest<UserViewModel>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
