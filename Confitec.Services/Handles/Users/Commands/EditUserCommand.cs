using Confitec.Core.Contracts;
using Confitec.Domain.Enums;
using Confitec.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Confitec.Services.Handles.Users.Commands
{
    public sealed class EditUserCommand : IRequest<UserViewModel>, IValidable
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }

        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string Schooling { get; set; }
    }
}
