using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Service.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuVM>> GetUserHaveMenu(MenuInput input);
        Task<IEnumerable<MenuVM>> GetAllMenu();
        Task<bool> Add(MenuInput mi);
     }
}
