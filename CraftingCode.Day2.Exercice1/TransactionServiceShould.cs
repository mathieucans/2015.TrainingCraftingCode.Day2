using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftingCode.Day2.Exercice1.Acceptance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CraftingCode.Day2.Exercice1
{
	[TestClass]
	public class TransactionServiceShould
	{
		private TransactionService transactionService;

		[TestInitialize]
		public void Initialize()
		{
			transactionService = new TransactionService();	
		}

		[TestMethod]
		public void returns_an_empty_transaction_list_when_no_operation_has_been_done()
		{
			var transactionList = transactionService.GetAllTransactions();

			Assert.AreEqual(0, transactionList.Count());
		}

		[TestMethod]
		public void store_a_deposit_transaction_to_the_alltrancactionList()
		{
			transactionService.StoreDeposit(100);
			
			var transactions = transactionService.GetAllTransactions();
			
			Assert.AreEqual(1, transactions.Count());
			CollectionAssert.AllItemsAreNotNull(transactions.ToArray());
		}
	}
}
