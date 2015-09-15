using System;
using System.Collections.Generic;

namespace CraftingCode.Day2.Exercice1.Acceptance
{
	internal class TransactionService : ITransactionService
	{
		private readonly IList<Transaction> _transactions = new List<Transaction>();

		public TransactionService()
		{
		}

		public IEnumerable<Transaction> GetAllTransactions()
		{
			return _transactions;
		}

		public void StoreDeposit(int amount)
		{
			_transactions.Add(new Transaction());
		}

		public void StoreWithDraw(int amount)
		{
			_transactions.Add(new DebitTransaction());
		}
	}
}