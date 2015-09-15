using System.Collections.Generic;

namespace CraftingCode.Day2.Exercice1
{
	public interface ITransactionService
	{
		IEnumerable<Transaction> GetAllTransactions();
		void StoreDeposit(int amount);
		void StoreWithDraw(int amount);
	}
}