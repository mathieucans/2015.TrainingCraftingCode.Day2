using CraftingCode.Day2.Exercice1.Acceptance;

namespace CraftingCode.Day2.Exercice1
{
	public class AccountService
	{
		private readonly ITransactionService _transactionService;
		private readonly IPrintService _printService;

		public AccountService(ITransactionService transactionService, IPrintService printService)
		{
			_transactionService = transactionService;
			_printService = printService;
		}

		public void Deposit(int amount)
		{
			_transactionService.StoreDeposit(amount);
		}

		public void Withdraw(int amount)
		{
			_transactionService.StoreWithDraw(amount);			
		}

		public void PrintStatement()
		{
			var transactions = _transactionService.GetAllTransactions();
			_printService.Print(transactions);
		}

	}
}