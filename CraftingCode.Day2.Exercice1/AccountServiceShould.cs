using System;
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

		[TestInitialize]
		public void Initialize()
		{
			transactionService = new Mock<ITransactionService>();
			dateService = new Mock<IDateService>();
			accountService = new AccountService(dateService.Object, transactionService.Object);
		}

		[TestMethod]
		public void create_transaction_to_the_transaction_service()
		{
			var date = DateTime.Now;
			dateService.Setup(s => s.Now()).Returns(date);

			accountService.Deposit(500);

			transactionService.Verify(s => s.Create(500, date), Times.Once);
		}
	}

	public interface IDateService
	{
		DateTime Now();
	}

	public interface ITransactionService
	{
		void Create(int amount, DateTime date);
	}
}