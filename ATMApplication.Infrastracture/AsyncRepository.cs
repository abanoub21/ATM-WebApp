using ATMApplication.Application.Contract;
using ATMApplication.Domain;
using Microsoft.EntityFrameworkCore;


namespace ATMApplication.Infrastracture
{
    public class AsyncRepository<T> : IAsyncRepsoitory<T> where T : class 
    {
        private readonly ATMContext db;

        public AsyncRepository(ATMContext db)
        {
            this.db = db;
        }

        public async Task<T> AddAsync(T Obj)
        {
            await db.Set<T>().AddAsync(Obj);
            await db.SaveChangesAsync();
            return Obj;
        }
        public async Task<Account> LoginAsync(Account obj)
        {
            var user = await db.Accounts.FirstOrDefaultAsync(u => u.UserName == obj.UserName && u.Password == obj.Password);
            if (user == null)
                return null;
            else
                return user;
        }
       
        public async Task<T> GetAsyncByIDAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);

        }

        public async Task<T> UpdateAsync(T Obj)
        {
            db.Entry(Obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Obj;
        }
        public async Task<List<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync(); 
        }
    }
}
    