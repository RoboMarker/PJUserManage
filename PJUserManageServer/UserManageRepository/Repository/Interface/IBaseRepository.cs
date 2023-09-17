using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.Models.Data;

namespace UserManageRepository.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        //IContextRepository ContextRepository { get; set; }

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        T Add(T pi);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
