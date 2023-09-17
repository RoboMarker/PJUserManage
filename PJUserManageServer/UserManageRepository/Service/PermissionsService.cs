using UserManageRepository.Models.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Repository.Interface;
using UserManageRepository.Service.Interface;

namespace UserManageRepository.Service
{
    public class PermissionsService : IPermissionsService
    {
        IPermissionsRepository _ipermissionsRepository = null;
        public PermissionsService(IPermissionsRepository ipermissionsRepository)
        {
            this._ipermissionsRepository = ipermissionsRepository;
        }

        public async Task<IEnumerable<PermissionVM>> GetAllMenu()
        {
            return await this._ipermissionsRepository.GetAllMenu();
        }

        public async Task<Permission> Add(PermissionInpurt pi)
        {
            //MenuPermission mp = new MenuPermission();
            //MenuPermission p = new MenuPermission();
            //p.PermissionsName = pi.MenuName;

            // this._ipermissionsRepository.Add(p);

            //Menu m = new Menu();
            //m.MenuName = pi.MenuName;
            //m.Status = 1;
            //m.CreateDate = DateTime.Now;
            //m.CreateUser = pi.UserId;//需要修正
            //m.MenuType = 1;
            //var result = _DBconn.Insert<Menu>("Menu", m);
            //var NewM = this._menuRepository.GetMenu_for_MenuName(m.MenuName);

            //MenuPermission mp = new MenuPermission();
            //mp.MenuId = NewM.Id;
            //mp.MenuPermissionsType = "";
            //mp.PermissionsId = pi.PermissionsId;
            //var result = _DBconn.Insert<MenuPermission>("MenuPermissions", mp);
            //var result = 0;
            return null;

        }

        public async Task<int> Update(int MenuPermissionsId, MenuPermission mp)
        {
            return await this._ipermissionsRepository.Update(MenuPermissionsId, mp);
        }

        public async Task<int> Delete(int MenuPermissionsId)
        {
            return await this._ipermissionsRepository.Delete(MenuPermissionsId);
        }

    }
}
