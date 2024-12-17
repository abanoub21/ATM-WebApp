using ATMApplication.Application.Dto;

namespace ATMApplication.Application.Contract
{
    public interface IUserAccountService
    {
        Task<UserAccountDto> Login(UserAccountDto obj);
        Task<UserAccountDto> Rigester(UserAccountDto obj);
    }
}
