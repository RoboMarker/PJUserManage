using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Repository.Interface
{
    public interface IMenuRepository
    {

        Task<IList<MenuVM>> GetMenu_For_All(MenuInput input);
        Task<IList<MenuVM>> GetMenu_for_Permissions(MenuInput input);
        Task<IList<MenuVM>> GetMenu_for_User(MenuInput input);
        Task<IEnumerable<MenuVM>> GetAllMenu();

        Task<int> Add(Menu mi);
    }
}
