using ATMApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Application.Contract
{
    public interface IAccountAppService
    {
        Task<AccountDto> GetAccountById(int accountId);
        Task<AccountDto> Deposit(int accountId, int amount);
        Task<AccountDto> Withdraw(int accountId, int amount);
        Task<List<AccountDto>> GetAll();
    }
}
