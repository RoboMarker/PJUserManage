using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;

namespace UserManageRepository.Service.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuVM>> GetUserHaveMenu(MenuInput input);
        Task<IEnumerable<MenuVM>> GetAllMenu();

        Task<int> Add(MenuInput mi);
     }
}
