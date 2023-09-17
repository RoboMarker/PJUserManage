using Microsoft.AspNetCore.Mvc;
using UserManageRepository.Models.Input;
using UserManageRepository.Service.Interface;

namespace PJUserManage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : Controller
    {

        private readonly IMenuService _imenuService;
        public MenuController(IMenuService imenuService)
        {
            _imenuService = imenuService;
        }

        [HttpPost]
        public async Task<bool> Add(MenuInput mp)
        {
            try
            {
                 var bResult=await this._imenuService.Add(mp);
                return bResult;
            }
            catch
            { 
                return false;
            }
        }


        [HttpGet("GetAllMenu")]
        public async Task<IActionResult> GetAllMenu()
        {
          //  MenuInput input = new MenuInput();
          //  input.UserId = UserId;
            return Ok(await _imenuService.GetAllMenu());

        }


        [HttpGet("GetUserHaveMenu")]
        public async Task<IActionResult> GetUserHaveMenu([FromQuery] MenuInput input)
        {
            return Ok(await _imenuService.GetUserHaveMenu(input));
        }
    }
}
