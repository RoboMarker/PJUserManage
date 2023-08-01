using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Service.Interface
{
    public interface IPermissionsService
    {
        Task<IEnumerable<PermissionVM>> GetAllMenu();

        Task<int> Add(PermissionInpurt pi);

        Task<int> Update(int MenuPermissionsId, MenuPermission mp);

        Task<int> Delete(int MenuPermissionsId);
    }
}
