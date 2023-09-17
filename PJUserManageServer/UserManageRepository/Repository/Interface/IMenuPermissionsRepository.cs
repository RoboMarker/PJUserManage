using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.DataModels.Data;

namespace UserManageRepository.Repository.Interface
{
    public interface IMenuPermissionsRepository
    {
        UserManageRepository.Models.Data.MenuPermission Add(UserManageRepository.Models.Data.MenuPermission mp);
        Task<Models.Data.MenuPermission> AddAsync(Models.Data.MenuPermission mi);  
    }
}
