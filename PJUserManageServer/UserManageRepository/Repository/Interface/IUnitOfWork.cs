using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManageRepository.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task BeginTransactionAsync();

        void Commit();

        Task CommitAsync();

        void Rollback();
        Task RollbackAsync();
    }
}
