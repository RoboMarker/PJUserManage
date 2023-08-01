using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Repository.Interface
{
    public interface IPermissionsRepository
    {
         Task<IEnumerable<PermissionVM>> GetAllMenu();

        Task<int> Add(PermissionInpurt pi);

        Task<int> Update(int MenuPermissionsId,MenuPermission mp);

        Task<int> Delete(int MenuPermissionsId);
    }
}
