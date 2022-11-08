using Confitec.Core.Exceptions;
using Confitec.Infra.Contracts;
using System.Threading.Tasks;

namespace Confitec.Services.Handles
{
    public class BaseHandler
    {
        private readonly IUnitOfWork _uow;

        public BaseHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CommitAsync()
        {
            if (await _uow.CommitAsync()) return;

            throw new DomainException("Ocorreu um erro ao tentar salvar os dados");
        }
    }
}
