using Confitec.Core.Exceptions;
using Confitec.Domain.Entities;
using Confitec.Domain.Enums;
using Confitec.Infra.Contracts;
using Confitec.Services.Handles.Users.Commands;
using Confitec.Services.Handles.Users.Contracts;
using Confitec.Services.Projections;
using Confitec.Services.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handles.Users
{
    public sealed class UserHandler : BaseHandler, IUserHandler
    {
        private readonly IUserRepository _userRepository;
        public UserHandler(IUnitOfWork uow, IUserRepository userRepository) : base(uow)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            var schooling = (SchoolingEnum)Enum.Parse(typeof(SchoolingEnum), request.Schooling);

            var user = new User(request.Name, request.LastName, request.Email, request.BirthDate.Value, schooling);

            await _userRepository.CreateAsync(user);

            await CommitAsync();

            return user.ToViewModel();
        }

        public async Task<UserViewModel> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Id == request.Id);
            if (user is null) throw new DomainException("Usuário não encontrado");

            await Validate(request);

            var schooling = (SchoolingEnum)Enum.Parse(typeof(SchoolingEnum), request.Schooling); 

            user.Update(request.Name, request.LastName, request.Email, request.BirthDate.Value, schooling);

            await _userRepository.UpdateAsync(user);

            await CommitAsync();

            return user.ToViewModel();
        }

        public async Task<UserViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Id == request.Id);
            if (user is null) throw new DomainException("Usuário não encontrado");

            await _userRepository.RemoveAsync(user);

            await CommitAsync();

            return user.ToViewModel();
        }

        private async Task Validate(EditUserCommand request)
        {
            if (await _userRepository.AnyAsync(x => x.Email.Address == request.Email && x.Id != request.Id))
                throw new DomainException("Já existe um usuário cadastrado com o email informado");

            if (!Enum.IsDefined(typeof(SchoolingEnum), int.Parse(request.Schooling)))
                throw new DomainException("Escolaridade inválida");

            if (request.BirthDate.Value.Date > DateTime.UtcNow.Date)
                throw new DomainException("Data de nascimento não pode ser maior que a data de hoje");
        }

        private async Task Validate(CreateUserCommand request)
        {
            if (await _userRepository.AnyAsync(x => x.Email.Address == request.Email))
                throw new DomainException("Já existe um usuário cadastrado com o email informado");

            if (!Enum.IsDefined(typeof(SchoolingEnum), int.Parse(request.Schooling)))
                throw new DomainException("Escolaridade inválida");

            if (request.BirthDate.Value.Date > DateTime.UtcNow.Date)
                throw new DomainException("Data de nascimento não pode ser maior que a data de hoje");
        }
    }
}
