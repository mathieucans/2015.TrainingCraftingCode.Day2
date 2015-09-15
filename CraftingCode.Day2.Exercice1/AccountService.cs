using CraftingCode.Day2.Exercice1.Acceptance;

namespace CraftingCode.Day2.Exercice1
{
	public class AccountService
	{
		private readonly IDateService _dateService;
		private readonly ITransactionService _transactionService;
		private readonly IPrintService _printService;

		public AccountService(IDateService dateService, ITransactionService transactionService, IPrintService printService)
		{
			_dateService = dateService;
			_transactionService = transactionService;
			_printService = printService;
		}

		public void Deposit(int amount)
		{
			var date = _dateService.Now();
			_transactionService.Create(amount, date);
		}

		public void Withdraw(int amount)
		{
			var date = _dateService.Now();
			_transactionService.Create(-1*amount, date);			
		}

		public void PrintStatement()
		{
			var transactions = _transactionService.GetAllTransactions();
			_printService.Print(transactions);
		}

	}
}