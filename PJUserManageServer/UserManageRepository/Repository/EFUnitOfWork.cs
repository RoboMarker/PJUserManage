using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.Context;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly dbCustomDbSampleContext _dbContext;
        private IDbContextTransaction _dbTransaction;
        public EFUnitOfWork(dbCustomDbSampleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _dbTransaction = await _dbContext.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            try
            {
               // int iResult = _dbContext.SaveChanges();
                _dbTransaction.Commit();
            }
            catch (Exception)
            {
                _dbTransaction.Rollback();
                throw;
            }
            finally
            {
                _dbTransaction.Dispose();
            }
        }
        public async Task CommitAsync()
        {
            try
            {
                _dbTransaction.CommitAsync();
            }
            catch (Exception)
            {
                _dbTransaction.Rollback();
                throw;
            }
            finally
            {
                _dbTransaction.Dispose();
            }

        }

        public void Dispose()
        {
            _dbTransaction?.Dispose();
        }
        public void Rollback()
        {
             _dbTransaction.Rollback();
        }
        public async Task RollbackAsync()
        {
            await _dbTransaction.RollbackAsync();
        }
    }
}
