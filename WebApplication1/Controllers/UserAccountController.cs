using ATMApplication.Application.Contract;
using ATMApplication.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService service;

        public UserAccountController(IUserAccountService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<UserAccountDto> Rigester(UserAccountDto obj)
        {
            return await service.Rigester(obj);
        }
        [HttpPut]
        public async Task<UserAccountDto> Login(UserAccountDto obj)
        {
            return await service.Login(obj);
        }
    }
}
