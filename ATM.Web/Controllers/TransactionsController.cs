using ATMApplication.Application.Contract;
using ATMApplication.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Web.Controllers
{
	public class TransactionsController : Controller

	{
		private readonly IAccountAppService service;

		public TransactionsController(IAccountAppService service)
		{
			this.service = service;
		}
        public async Task<IActionResult> Deposit()
        {

            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Deposit(AccountDto obj)
		{
			var account = await service.Deposit(obj.Id, obj.Balance);
			return RedirectToAction("Result");
		}
		public async Task<IActionResult> Withdraw(int accountId, int amount)
		{
			var account = await service.Withdraw(accountId, amount);
			return View(account);
		}
		public async Task<IActionResult> Result()
		{
			var x = await service.GetAll();
			return View();
		}
	}
}
