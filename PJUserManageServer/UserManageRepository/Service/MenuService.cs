using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;
using UserManageRepository.Service.Interface;

namespace UserManageRepository.Service
{
    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;
        IPermissionsRepository _permissionsRepository;
        public MenuService(IMenuRepository menuRepository, IPermissionsRepository permissionsRepository)
        {
            this._menuRepository = menuRepository;
            this._permissionsRepository = permissionsRepository;
        }


        public async Task<IEnumerable<MenuVM>> GetUserHaveMenu(MenuInput input)
        {
            IList<MenuVM> result = await _menuRepository.GetMenu_For_All(input);

            return result;
        }

        public async Task<IEnumerable<MenuVM>> GetAllMenu()
        {
            IEnumerable<MenuVM> result = await _menuRepository.GetAllMenu();

            return result;
        }

        public async Task<int> Add(MenuInput mi)
        {
            //MenuPermission mp = new MenuPermission();
            Menu m = new Menu();
            m.MenuName = mi.MenuName;
            m.Status = 1;
            m.MenuType = 1;
            m.PermissionsId = mi.PermissionsId.ToString();

            MenuPermission p = new MenuPermission();

            var iResult = this._menuRepository.Add(m);
            return iResult.Result;
        }
    }
}
