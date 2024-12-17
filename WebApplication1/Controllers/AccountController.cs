using ATMApplication.Application.Contract;
using ATMApplication.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService service;

        public AccountController(IAccountAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<AccountDto> GetAccountById(int accountId)
        {
           return await service.GetAccountById(accountId);
        }
        [HttpPut]
        public async Task<AccountDto> Deposit(int accountId, int amount)
        {
            return await service.Deposit(accountId, amount);
        }
        [HttpPut]
        public async Task<AccountDto> Withdraw(int accountId, int amount)
        {
            return await service.Withdraw(accountId, amount);       
        }
    }
}
