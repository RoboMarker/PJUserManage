using Microsoft.AspNetCore.Mvc;
using UserManageRepository.Context;
using UserManageRepository.Interface;


namespace PJUserManage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManageController : ControllerBase
    {
        private readonly IUserRepositoryEnity _IUserRepository;
        public UserManageController(dbCustomDbSampleContext context, IUserRepositoryEnity users)
        {
            _IUserRepository = users;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _IUserRepository.GetUser());
        }
    }
}
