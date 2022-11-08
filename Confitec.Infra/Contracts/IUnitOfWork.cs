using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infra.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
