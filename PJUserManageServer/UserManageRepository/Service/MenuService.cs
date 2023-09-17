using UserManageRepository.Models.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;
using UserManageRepository.Service.Interface;

namespace UserManageRepository.Service
{
    public class MenuService : IMenuService
    {
        IUnitOfWork _contextRepository;
        private readonly IBaseRepository<Menu> _menuRepository;
        private readonly IBaseRepository<MenuPermission> _menuPermissionsRepository;

        public MenuService(IUnitOfWork contextRepository,IBaseRepository<Menu> menuRepository, IBaseRepository<MenuPermission> menuPermissionsRepository)
        {
            this._menuRepository = menuRepository;
            this._contextRepository = contextRepository;
            this._menuPermissionsRepository = menuPermissionsRepository;
        }

        public async Task<bool> Add(MenuInput mi)
        {
            bool bResult = false;
            this._contextRepository.BeginTransaction();
            try
            {
                Menu m = new Menu();
                m.MenuName = mi.MenuName;
                m.Status = (byte)eStatus.active;
                m.MenuType = 1;
                m.PermissionsId = mi.PermissionsId.ToString();
                var iResult =  this._menuRepository.Add(m);

                MenuPermission mp = new MenuPermission();
                mp.MenuId = m.MenuId;
                mp.PermissionsId = mi.PermissionsId;
                mp.MenuPermissionsType = (byte)eMenuPermissionsType.Permissions;
                this._menuPermissionsRepository.Add(mp);

                this._contextRepository.Commit();
                bResult=true;
            }
            catch (Exception ex)
            {
                this._contextRepository.Rollback();
            }
            finally
            {
                this._contextRepository.Dispose();
            }
            return bResult;
        }

        public async Task<IEnumerable<MenuVM>> GetUserHaveMenu(MenuInput input)
        {
            IList<MenuVM> result = null;
           // IList<MenuVM> result = await _menuRepository.GetMenu_For_All(input);

            return result;
        }

        public async Task<IEnumerable<MenuVM>> GetAllMenu()
        {
            IEnumerable<MenuVM> result=null;
            //    result = await _menuRepository.GetAllMenu();

            return result;
        }
    }
}
