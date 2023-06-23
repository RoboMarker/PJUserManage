using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.Models.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Repository.Interface;
using UserManageRepository.Repository;
using UserManageRepository.Models.ViewModels;
using System.Collections;

namespace UserManageRepository.Service.Interface
{
    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }


        public async Task<IEnumerable<MenuVM>> GetUserHaveMenu(MenuInput input)
        {
            IList<MenuVM> result = await _menuRepository.GetMenu_For_All(input);

            return result;
        }

        public async Task<IEnumerable<MenuVM>> GetAllMenu(MenuInput input)
        {
            IEnumerable<MenuVM> result = await _menuRepository.GetAllMenu(input);

            return result;
        }
    }
}
