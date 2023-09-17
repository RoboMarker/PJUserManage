using Microsoft.AspNetCore.Mvc;
using UserManageRepository.DataModels.Data;
using UserManageRepository.Models.Input;
using UserManageRepository.Models.ViewModels;
using UserManageRepository.Service.Interface;


namespace PJUserManage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : Controller
    {
        IPermissionsService _permissionsService;
        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;

        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<PermissionVM>> GetAll()
        {
            return await this._permissionsService.GetAllMenu();
        }

        [HttpPost]
        public async Task<int> Add(PermissionInpurt mp)
        {
           var result= this._permissionsService.Add(mp);
            return 1;
        }

        [HttpPut]
        public async Task<int> Update(int MenuPermissionsId, UserManageRepository.Models.Data.MenuPermission mp)
        {
            return await this._permissionsService.Update(MenuPermissionsId, mp);
        }

        [HttpDelete]
        public async Task<int> Delete(int MenuPermissionsId)
        {
            return await this._permissionsService.Delete(MenuPermissionsId);
        }
    }
}
