using Microsoft.AspNetCore.Mvc;
using UserManageRepository.Context;
using UserManageRepository.Interface;
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
        public async Task<int> Add(MenuInput mp)
        {
            return await this._imenuService.Add(mp);
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
