namespace CraftingCode.Day2.Exercice1
{
	public class AccountService
	{
		private readonly IDateService _dateService;
		private readonly ITransactionService _transactionService;

		public AccountService(IDateService dateService, ITransactionService transactionService)
		{
			_dateService = dateService;
			_transactionService = transactionService;
		}

		public void Deposit(int amount)
		{
			var date = _dateService.Now();
			_transactionService.Create(amount, date);
		}

		public void Withdraw(int amount)
		{
			
		}

		public void PrintStatement()
		{
			
		}

	}
}