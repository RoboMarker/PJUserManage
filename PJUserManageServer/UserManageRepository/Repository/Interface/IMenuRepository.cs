using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Repository.Interface
{
    public interface IMenuRepository
    {

        Task<IList<MenuVM>> GetMenu_For_All(MenuInput input);
        Task<IList<MenuVM>> GetMenu_for_Permissions(MenuInput input);
        Task<IList<MenuVM>> GetMenu_for_User(MenuInput input);
        Task<IEnumerable<MenuVM>> GetAllMenu(MenuInput input);
    }
}
