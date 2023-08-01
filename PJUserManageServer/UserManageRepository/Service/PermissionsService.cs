using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.DataModels.Data;
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

        public async Task<int> Add(PermissionInpurt pi)
        {
            //MenuPermission mp = new MenuPermission();
            return await this._ipermissionsRepository.Add(pi);
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
