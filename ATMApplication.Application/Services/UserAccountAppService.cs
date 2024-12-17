using ATMApplication.Application.Contract;
using ATMApplication.Application.Dto;
using ATMApplication.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Application.Services
{
    public class UserAccountAppService : IUserAccountService
    {
        private readonly IAsyncRepsoitory<Account> accountRepo;
        private readonly IMapper mapper;

        public UserAccountAppService(IAsyncRepsoitory<Account> accountRepo, IMapper mapper)
        {
            this.accountRepo = accountRepo;
            this.mapper = mapper;
        }

        public async Task<UserAccountDto> Login(UserAccountDto obj)
        {
           var data = mapper.Map<Account>(obj);
            var user = await accountRepo.LoginAsync(data);
            return mapper.Map<UserAccountDto>(user); 
        }

        public async Task<UserAccountDto> Rigester(UserAccountDto obj)
        {
          
            var newObj = mapper.Map<Account>(obj);
            var data = await accountRepo.AddAsync(newObj);
            return mapper.Map<UserAccountDto>(data);   

        }
    }
}
