using ATMApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Application.Contract
{
    public interface IAsyncRepsoitory<T>
    {
        Task<T> GetAsyncByIDAsync(int id);
        Task<T> UpdateAsync(T Obj);
        Task<T> AddAsync(T Obj);
        Task<Account> LoginAsync(Account obj);
        Task<List<T>> GetAll();
    }
}
