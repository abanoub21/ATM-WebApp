using ATMApplication.Application.Contract;
using ATMApplication.Application.Dto;
using ATMApplication.Domain;
using AutoMapper;

namespace ATMApplication.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAsyncRepsoitory<Account> accountrepo;
        private readonly IMapper mapper;

        public AccountAppService(IAsyncRepsoitory<Account> accountrepo, IMapper mapper)
        {
            this.accountrepo = accountrepo;
            this.mapper = mapper;
        }
        public async Task<AccountDto> Deposit(int accountId, int amount)
        {
            var obj = new AccountDto();
            obj.Id = accountId;
            obj.Balance = amount;

            var old = mapper.Map<Account>(obj);
            var account = await accountrepo.GetAsyncByIDAsync(obj.Id);

            account.Balance += amount;
            await accountrepo.UpdateAsync(account);
            return mapper.Map<AccountDto>(obj);
        }
        public async Task<AccountDto> GetAccountById(int accountId)
        {
            var id = await accountrepo.GetAsyncByIDAsync(accountId);
            return mapper.Map<AccountDto>(id);

        }

        public async Task<List<AccountDto>> GetAll()
        {
            var all = await accountrepo.GetAll();
            return mapper.Map<List<AccountDto>>(all); 
        }

        public async Task<AccountDto> Withdraw(int accountId, int amount)
        {
            var obj = new AccountDto();
            obj.Id = accountId;
            obj.Balance = amount;

            var old = mapper.Map<Account>(obj);

            var account = await accountrepo.GetAsyncByIDAsync(obj.Id);

            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                await accountrepo.UpdateAsync(account);
            }
            else
            {
                throw new Exception("Insufficient funds");
            }
            return mapper.Map<AccountDto>(obj);
             

        }
    }
}
