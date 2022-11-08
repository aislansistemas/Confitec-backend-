using Confitec.Core.Contracts;
using Confitec.Domain.Enums;
using Confitec.Services.ViewModels;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Services.Handles.Users.Commands
{
    public sealed class CreateUserCommand : IRequest<UserViewModel>, IValidable
    {
        [Required(ErrorMessage = "Nome é obrigatório"), MaxLength(255, ErrorMessage = "Nome de conter no maxímo 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório"), MaxLength(255, ErrorMessage = "Sobrenome de conter no maxímo 255 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email é obrigatário"), 
        MaxLength(255, ErrorMessage = "Email de conter no maxímo 255 caracteres"), 
        EmailAddress(ErrorMessage = "Email está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Escolaridade é obrigatório")]
        public string Schooling { get; set; }
    }
}
