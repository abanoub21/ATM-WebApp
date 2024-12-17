using ATMApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace ATMApplication.Infrastracture
{
    public class ATMContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }  = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ATMApplication;integrated security=true;");
        }
    }
}
