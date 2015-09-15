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
		private Mock<IDateService> dateService;
		private AccountService accountService;
		private Mock<IPrintService> printService;

		[TestInitialize]
		public void Initialize()
		{
			transactionService = new Mock<ITransactionService>();
			dateService = new Mock<IDateService>();
			printService = new Mock<IPrintService>();
			accountService = new AccountService(dateService.Object, transactionService.Object, printService.Object);
		}

		[TestMethod]
		public void create_positive_transaction_on_deposit()
		{
			var date = DateTime.Now;
			dateService.Setup(s => s.Now()).Returns(date);

			accountService.Deposit(500);

			transactionService.Verify(s => s.Create(500, date), Times.Once);
		}

		[TestMethod]
		public void create_negative_transaction_on_withdraw()
		{
			var date = DateTime.Now;
			dateService.Setup(s => s.Now()).Returns(date);

			accountService.Withdraw(200);
				
			transactionService.Verify(s => s.Create(-200, date), Times.Once);
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
		void Create(int amount, DateTime date);
		IEnumerable<Transaction> GetAllTransactions();
	}
}