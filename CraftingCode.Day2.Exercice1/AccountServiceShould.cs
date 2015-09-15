using System;
using System.Collections;
using System.Collections.Generic;
using CraftingCode.Day2.Exercice1.Acceptance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CraftingCode.Day2.Exercice1
{
	[TestClass]
	public class AccountServiceShould
	{
		private Mock<ITransactionService> transactionService;
		private AccountService accountService;
		private Mock<IPrintService> printService;

		[TestInitialize]
		public void Initialize()
		{
			transactionService = new Mock<ITransactionService>();
			printService = new Mock<IPrintService>();
			accountService = new AccountService(transactionService.Object, printService.Object);
		}

		[TestMethod]
		public void create_deposit_transaction_on_deposit()
		{
			accountService.Deposit(500);

			transactionService.Verify(s => s.StoreDeposit(500), Times.Once);
		}

		[TestMethod]
		public void store_withdraw_transaction_on_withdraw()
		{
			accountService.Withdraw(200);
				
			transactionService.Verify(s => s.StoreWithDraw(200), Times.Once);
		}

		[TestMethod]
		public void give_all_transactions_to_the_printservice_on_PrintStatement()
		{
			var alltransactions = new List<Transaction>();
			transactionService.Setup(s => s.GetAllTransactions()).Returns(alltransactions);
			
			accountService.PrintStatement();

			printService.Verify(
				s => s.Print(alltransactions), Times.Once);
		}
	}

	public interface IDateService
	{
		DateTime Now();
	}

	public interface ITransactionService
	{
		IEnumerable<Transaction> GetAllTransactions();
		void StoreDeposit(int amount);
		void StoreWithDraw(int amount);
	}
}