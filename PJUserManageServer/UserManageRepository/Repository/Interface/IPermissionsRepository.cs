using UserManageRepository.Models.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Repository.Interface
{
    public interface IPermissionsRepository
    {
         Task<IEnumerable<PermissionVM>> GetAllMenu();

        Task<Permission> Add(Permission pi);

        Task<int> Update(int MenuPermissionsId, Models.Data.MenuPermission mp);

        Task<int> Delete(int MenuPermissionsId);
    }
}
